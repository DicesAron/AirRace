using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
public class GameManager : MonoBehaviour
{
    string felhID;
    public int allas = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allas == 3)
        {
            StreamReader fel = new StreamReader("Assets/felh/user.txt");
            felhID = fel.ReadToEnd();
            string connStr = $"server=localhost;user=root;database=airrace;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql2 = $"UPDATE `kikepzes` SET `tejesitve`='1' WHERE `userID`='{felhID}'AND `palya`=1";
            MySqlCommand cmd = new MySqlCommand(sql2, conn);
            cmd.ExecuteNonQuery();
            UnityEngine.SceneManagement.SceneManager.LoadScene("sikeres");
        }
    }
}
