using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Regload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Regisztacio");
    }

    public void Belepload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Belepes");
    }

    public void FomenuLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fomenu");
    }
}
