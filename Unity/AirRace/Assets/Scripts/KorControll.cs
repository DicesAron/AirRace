using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorControll : MonoBehaviour
{

    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Repulo"))
        {
            gamemanager.allas += 1;
            Destroy(gameObject);
            Debug.Log("cds");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
