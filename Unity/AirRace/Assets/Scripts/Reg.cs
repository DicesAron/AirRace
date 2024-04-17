using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
public class Reg : MonoBehaviour
{
    List<string> nevek = new List<string>();
    string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
    string nev;
    string email;
    string pass1;
    string pass2;
    string id;
    [SerializeField] TextMeshProUGUI siker;
    [SerializeField] TextMeshProUGUI hiba;
    static string kisbetu = "abcde���lkjhgfsyx�vmnqwrtzuiop�����";
    string nagybetu = kisbetu.ToUpper();
    string szam = "0123456789";
    bool kicsib = false;
    bool nagyb = false;
    bool szamb = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void inputNev(string input) {
        nev = input;
    }
    public void inputEmail(string input)
    {
        email = input;
    }
    public void inputPass1(string input)
    {
        pass1 = input;
    }
    public void inputPass2(string input)
    {
        pass2 = input;
    }

    public void regisztralas() {
        siker.text = ".";
        if (nev != "" && email != "" && pass1 != "" && pass2 != "")
        {
            
            if (nev.Length < 13)
            {
                
                if (email.Contains('@') && email.Contains('.') && (email.IndexOf('.') > (email.IndexOf('@') + 1)))
                {
                    
                    if (email.Length < 41)
                    {
                        if (pass1 == pass2)
                        {
                            if (pass1.Length < 41 && pass1.Length > 5)
                            {
                                foreach (char item in kisbetu)
                                {
                                    if (pass1.Contains(item))
                                    {
                                        kicsib = true;
                                        break;
                                    }
                                }
                                foreach (char item in nagybetu)
                                {
                                    if (pass1.Contains(item))
                                    {
                                        nagyb = true;
                                        break;
                                    }
                                }
                                foreach (char item in szam)
                                {
                                    if (pass1.Contains(item))
                                    {
                                        szamb = true;
                                        break;
                                    }
                                }
                                if (kicsib == true && nagyb == true && szamb == true)
                                {
                                    MySqlConnection conn = new MySqlConnection(connStr);
                                    try
                                    {
                                        conn.Open();
                                        string sql = "SELECT `Nev` FROM `user`;";
                                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                                        MySqlDataReader rdr = cmd.ExecuteReader();
                                        while (rdr.Read())
                                        {
                                            nevek.Add(rdr[0].ToString());
                                        }
                                        rdr.Close();
                                    }
                                    catch (System.Exception ex)
                                    {

                                        hiba.text = $"HIBA: {ex.ToString()}";
                                    }
                                    conn.Close();
                                    if (!nevek.Contains(nev))
                                    {   //User hozz�ad�sa az adatb�zishoz
                                        try
                                        {
                                            
                                            conn.Open();
                                            string sql2 = $"INSERT INTO `user`(`Nev`, `Email`, `Pass`) VALUES ('{nev}','{email}','{pass1}')";
                                            MySqlCommand cmd = new MySqlCommand(sql2, conn);
                                            cmd.ExecuteNonQuery();
                                            siker.text = "Sikeres regisztr�ci�";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            hiba.text = $"HIBA: {ex.ToString()}";
                                            throw;
                                        }
                                        conn.Close();
                                        //Az el�bb felvett usernak az ID lek�rdez�se
                                        try
                                        {
                                            conn.Open();
                                            string sql = $"SELECT `ID` FROM `user` WHERE `Nev` = '{nev}'";
                                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                                            MySqlDataReader rdr = cmd.ExecuteReader();
                                            while (rdr.Read())
                                            {
                                                id=rdr[0].ToString();
                                            }
                                            rdr.Close();
                                        }
                                        catch (System.Exception ex)
                                        {

                                            hiba.text = $"HIBA: {ex.ToString()}";
                                        }
                                        conn.Close();

                                        //kikepzes t�bl�ba p�ly�k felv�tele
                                        try
                                        {

                                            conn.Open();
                                            string sql2 = $"INSERT INTO `kikepzes`(`userID`, `palya`, `tejesitve`) VALUES ('{id}','{1}','{0}')";
                                            MySqlCommand cmd = new MySqlCommand(sql2, conn);
                                            cmd.ExecuteNonQuery();
                                            siker.text = "Sikeres regisztr�ci�";
                                        }
                                        catch (System.Exception ex)
                                        {
                                            hiba.text = $"HIBA: {ex.ToString()}";
                                            throw;
                                        }
                                        conn.Close();
                                    }
                                    else
                                    {
                                        hiba.text = $"HIBA: Ilyen felhaszn�l�n�vvel m�r regisztr�ltak, k�rem adjon meg egy m�sikat!";
                                    }
                                }
                                else
                                {
                                    hiba.text = "HIBA: A jelsz� nem tartalmaz specifikus karaktereket!";

                                }
                            }  
                            else
                            {
                                hiba.text = "HIBA: Nem megfelel� jelsz�hossz!";
                            }
                        }
                        else
                        {
                            hiba.text = "HIBA: Nem egyeznek a jelszavak!";
                        }
                    }
                    else
                    {
                        hiba.text = "HIBA: T�l hossz� email c�m!";
                    }

                }
                else
                {
                    hiba.text = "HIBA: Nem megfelel� email form�tum!";
                }
            }
            else
            {
                hiba.text = "HIBA: Felhaszn�l�n�v maximum 12 karakter hossz� lehet!";
            }
        }
        else
        {
            hiba.text = "HIBA: Minden mez�t ki kell t�lteni!";
        }
        kicsib = false;
        nagyb = false;
        szamb = false;
    }
}

