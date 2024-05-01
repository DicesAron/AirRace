using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Esc : MonoBehaviour
{
    public GameObject menu;
    bool megjelenve = false;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (megjelenve == false)
            {
                menu.SetActive(true);
                megjelenve = true;
            }
            else
            {
                menu.SetActive(false);
                megjelenve = false;
            }
        }
    }
    public void Kilep() {
        Application.Quit();
    }
    public void Kijelentkezes() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fomenu");
    }
    public void JatekMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JatekMenu");
    }
}
