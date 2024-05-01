using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
public class Eredmenyek : MonoBehaviour
{
    int palya = 0;
    [SerializeField] TextMeshProUGUI tobbi;
    [SerializeField] TextMeshProUGUI jatekos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lekerdez(int palya) {
        string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            tobbi.text = "";
            int i = 1;
            conn.Open();
            string sql = $"SELECT user.Nev,akadaly.ido FROM `akadaly`,user WHERE user.ID=akadaly.userID AND `palya`='{palya}' AND akadaly.ido!='00:00:00' GROUP by user.ID ORDER BY `akadaly`.`ido` ASC LIMIT 3;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tobbi.text += $"#{i}\t{rdr[0].ToString()}\t {rdr[1].ToString().Split(':')[1]}:{rdr[1].ToString().Split(':')[2]}\n";
                i++;
            }
            rdr.Close();
        }
        catch (System.Exception)
        {
  
        }conn.Close();
    }


    public void btn1() {
        palya = 1;
        Lekerdez(palya);
    }

    public void btn2()
    {
        palya = 2;
        Lekerdez(palya);
    }

    public void btn3()
    {
        palya = 3;
        Lekerdez(palya);
    }
}
