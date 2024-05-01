using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
public class Kikepzes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI spec;
    int palya = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btn1() {
        palya = 1;
        spec.text = $"K�ldet�s:\n �thalad�si z�na �rint�se (3db)";
    }

    public void btn2()
    {
        string teljesitve = "";
        string connStr = "server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            
            string felhID;
            conn.Open();
            StreamReader fel = new StreamReader("AirRace_Data/user.txt");
            felhID = fel.ReadToEnd();
            string sql = $"SELECT `tejesitve` FROM `kikepzes` WHERE `palya`='1' AND `userID`='{felhID}';";
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
        if (teljesitve=="True")
        {
            palya = 2;
            spec.text = $"K�ldet�s:\n �thalad�si z�na �rint�se (4db)\n C�lpont kiiktat�sa (1db) \n lesz�ll�s";
        }
        else
        {
            spec.text = $"Teljes�ten� kell az el�z� p�ly�t";
        }
        
    }
    public void betolt() {
        if (palya==0)
        {
            spec.text = "Nem v�lasztott p�ly�t";
        }
        else if (palya==1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("palya");
        }
        else if (palya == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("palya2");
        }
    }
}
