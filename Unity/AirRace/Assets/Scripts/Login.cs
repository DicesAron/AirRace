using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
    string pass;
    string nev;
    string felhasznalo;
    public string userId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputNev(string input)
    {
        nev = input;
    }

    public void inputPass(string input)
    {
        pass = input;
    }

    public void belep() {
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string sql = $"SELECT `ID`,`Pass` FROM `user` WHERE `Nev` = '{nev}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                felhasznalo=rdr[0].ToString() + " " + rdr[1].ToString();
            }
            rdr.Close();
        }
        catch (System.Exception)
        {

            //hiba.text = $"HIBA: {ex.ToString()}";
        }
        conn.Close();
        if (felhasznalo != "")
        {
            if (felhasznalo.Split(' ')[1]==pass)
            {
                StreamWriter fel = new StreamWriter("Assets/felh/user.txt");
                fel.Write(felhasznalo.Split(' ')[0]);
                fel.Close();
                UnityEngine.SceneManagement.SceneManager.LoadScene("JatekMenu");
                
            }
            else
            {
                //hiba.text = $"HIBA: Rossz jelszó";
            }
        }
        else
        {
            //hiba.text = $"HIBA: Nincs ilyen felhasználó";
        }
    }
}
