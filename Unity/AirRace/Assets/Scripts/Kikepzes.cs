using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
        spec.text = $"Küldetés:\n Áthaladási zóna érintése (3db)";
    }

    public void betolt() {
        if (palya==0)
        {
            spec.text = "Nem választott pályát";
        }
        else if (palya==1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("palya1");
        }
    }
}
