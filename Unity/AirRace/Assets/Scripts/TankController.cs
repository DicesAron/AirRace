using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] ParticleSystem tuz = null;
    public Renderer atlatszo;
    public int talalat = 0;
    public GameManager gamemanager;
    private int megvolt = 0;
    private float vege;
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
            vege = Time.time+10;
            tuz.Play();
            atlatszo.enabled = false;
            gamemanager.allas += 1;
            megvolt += 1;
        }
        
        
    }
}
