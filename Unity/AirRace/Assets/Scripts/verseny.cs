using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
public class verseny : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI spec;
    int palya = 0;
    string felhID = "";
    // Start is called before the first frame update
    void Start()
    {
        StreamReader fel = new StreamReader("Assets/felh/user.txt");
        felhID = fel.ReadToEnd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn1()
    {
        
        string teljesitve = "";
        string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {

            
            conn.Open();
            string sql = $"SELECT `tejesitve` FROM `kikepzes` WHERE `palya`='2' AND `userID`='{felhID}';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                teljesitve = rdr[0].ToString();
            }
            rdr.Close();
        }
        catch (System.Exception ex)
        {

            spec.text = $"HIBA: {ex.ToString()}";
        }
        if (teljesitve == "True")
        {
            palya = 1;
            spec.text = $"Küldetés:\n Áthaladási zóna érintése (5db)\n Célpont kiiktatása (1db)";
        }
        else
        {
            spec.text = $"Teljesítení kell az elõzõ pályát";
        }
    }

    public void btn2()
    {

        string teljesitve = "";
        string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {

            
            conn.Open();
            string sql = $"SELECT `teljesitve` FROM `akadaly` WHERE `userID`='{felhID}' AND `palya` = '1';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                teljesitve = rdr[0].ToString();
            }
            rdr.Close();
        }
        catch (System.Exception ex)
        {

            spec.text = $"HIBA: {ex.ToString()}";
        }
        if (teljesitve == "True")
        {
            palya = 2;
            spec.text = $"Küldetés:\n Áthaladási zóna érintése (10db)";
        }
        else
        {
            spec.text = $"Teljesítení kell az elõzõ pályát";
        }
    }

    public void btn3()
    {

        string teljesitve = "";
        string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {

            string felhID;
            conn.Open();
            StreamReader fel = new StreamReader("Assets/felh/user.txt");
            felhID = fel.ReadToEnd();
            string sql = $"SELECT `teljesitve` FROM `akadaly` WHERE `userID`='{felhID}' AND `palya` = '2';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                teljesitve = rdr[0].ToString();
            }
            rdr.Close();
        }
        catch (System.Exception ex)
        {

            spec.text = $"HIBA: {ex.ToString()}";
        }
        if (teljesitve == "True")
        {
            palya = 3;
            spec.text = $"Küldetés:\n Áthaladási zóna érintése (5db)\n Célpont kiiktatása (1db)";
        }
        else
        {
            spec.text = $"Teljesítení kell az elõzõ pályát";
        }
    }
}
