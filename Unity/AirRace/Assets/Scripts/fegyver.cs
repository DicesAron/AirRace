using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fegyver : MonoBehaviour
{
    public Transform fegyverHelyzet;//innen infúl a lövedék
    public GameObject lovedekobject;//lövedék
    public float lovedekSebesseg = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            var lovedek = Instantiate(lovedekobject, fegyverHelyzet.position, fegyverHelyzet.rotation);//lemásolja(létrehozza) a lövedéket a prefab ból és beállítja a megadott helyzetbe
            lovedek.GetComponent<Rigidbody>().velocity = fegyverHelyzet.forward * lovedekSebesseg;//ez mozgatja a lövedéket

        }
    }
}
