using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI szoveg;
    public palya palya;
    string felhID;
    public int allas = 0;
    float ido;
    string feltido;
    public PlaneController repulo;
    bool kisebb;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader fel = new StreamReader("AirRace_Data/user.txt");
        felhID = fel.ReadToEnd();
    }

    public void lekerdez(int palya,string ido) {
        string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        string lekertido="";
        int voltmar=0;
        try
        {
            conn.Open();
            string sql = $"SELECT `ido`,`teljesitve` FROM `akadaly` WHERE `userID`='{felhID}' AND `palya`='{palya}';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                voltmar = Convert.ToInt32(rdr[1]);
                lekertido = rdr[0].ToString();
            }
            rdr.Close();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
        if (voltmar == 0)
        {
            kisebb = true;
           
        }
        else
        {
            if (Convert.ToInt32(lekertido.Split(':')[1]) <= Convert.ToInt32(ido.Split(':')[0]) && Convert.ToInt32(lekertido.Split(':')[2]) <= Convert.ToInt32(ido.Split(':')[1]))
            {
                kisebb = false;
                
            }
            else
            {
                kisebb = true;
                
            }
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        ido += Time.deltaTime;
        int perc = Mathf.FloorToInt(ido / 60);
        int masodperc = Mathf.FloorToInt(ido % 60);
        if (palya.palyaid == 1)
        {
            szoveg.text = $"Állapot: {allas}/3";
            if (allas == 3)
            {
                
                string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql2 = $"UPDATE `kikepzes` SET `tejesitve`='1' WHERE `userID`='{felhID}'AND `palya`=1";
                MySqlCommand cmd = new MySqlCommand(sql2, conn);
                cmd.ExecuteNonQuery();
                allas = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                
            }
        }
        else if (palya.palyaid==2)
        {
            szoveg.text = $"Állapot: {allas}/6";
            if (allas == 5 && repulo.leszalt==true)
            {
                
                string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql2 = $"UPDATE `kikepzes` SET `tejesitve`='1' WHERE `userID`='{felhID}'AND `palya`=2";
                MySqlCommand cmd = new MySqlCommand(sql2, conn);
                cmd.ExecuteNonQuery();
                allas = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                
            }
        }
        else if (palya.palyaid == 3)
        {
            szoveg.text = $"Állapot: {allas}/6 \n Idõ: {string.Format("{0:00}:{1:00}", perc, masodperc)}";
            if (allas == 6)
            {
                

                feltido = string.Format("{0:00}:{1:00}", perc, masodperc);
                lekerdez(1, feltido);
                if (kisebb)
                {
                    string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql2 = $"UPDATE `akadaly` SET `ido`='00:{feltido}',`teljesitve`='1' WHERE `userID`='{felhID}' AND	palya='1'";
                    MySqlCommand cmd = new MySqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                    
                }
                else
                {
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                }
                
            }
        }
        else if (palya.palyaid == 4)
        {
            szoveg.text = $"Állapot: {allas}/10 \n Idõ: {string.Format("{0:00}:{1:00}", perc, masodperc)}";
            if (allas == 10)
            {


                feltido = string.Format("{0:00}:{1:00}", perc, masodperc);
                lekerdez(2, feltido);
                if (kisebb)
                {
                    string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql2 = $"UPDATE `akadaly` SET `ido`='00:{feltido}',`teljesitve`='1' WHERE `userID`='{felhID}' AND	palya='2'";
                    MySqlCommand cmd = new MySqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");

                }
                else
                {
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                }

            }
        }
        else if (palya.palyaid == 5)
        {
            szoveg.text = $"Állapot: {allas}/5 \n Idõ: {string.Format("{0:00}:{1:00}", perc, masodperc)}";
            if (allas == 4 && repulo.leszalt == true)
            {


                feltido = string.Format("{0:00}:{1:00}", perc, masodperc);
                lekerdez(3, feltido);
                if (kisebb)
                {
                    string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql2 = $"UPDATE `akadaly` SET `ido`='00:{feltido}',`teljesitve`='1' WHERE `userID`='{felhID}' AND	palya='3'";
                    MySqlCommand cmd = new MySqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");

                }
                else
                {
                    allas = 0;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
                }

            }
        }


    }
}
