using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public int talalat = 0;
    public GameManager gamemanager;
    private int megvolt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("lovedek"))
        {
            if (talalat<6)
            {
                talalat += 1;
            }
            
            Debug.Log("Eltalaltak");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (talalat==5 && megvolt==0)
        {
            gamemanager.allas += 1;
            megvolt += 1;
        }
    }
}
