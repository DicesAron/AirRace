using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fegyver : MonoBehaviour
{
    
    public Transform fegyverHelyzet;//innen indúl a lövedék
    public GameObject lovedekobject;//lövedék
    public float lovedekSebesseg = 100f;
    public float lovesGyorsasag; // változó amivel megadjuk a lövésgyorsaságot
    private float kovLoves = 0; //eltárólja hogy mikor lõhetünk legközelebb
    //A mig 21 es gépfegyvere 3000-3600 lõvést adott le mp ként(0.02mp ként lõtt ki egy lövedéket)
    //Ezt lõszertakarékosság szempontjábõl felvittem 0.05 re
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loves();
    }

    void loves() {

        if (Input.GetKey(KeyCode.Space) && Time.time > kovLoves) //megnézi, hogy le van e nyomva a space és, hogy már eltelt e az az idõ
        {
            kovLoves = Time.time + lovesGyorsasag;
            var lovedek = Instantiate(lovedekobject, fegyverHelyzet.position, fegyverHelyzet.rotation);//lemásolja(létrehozza) a lövedéket a prefab ból és beállítja a megadott helyzetbe
            lovedek.GetComponent<Rigidbody>().velocity = fegyverHelyzet.forward * lovedekSebesseg;//ez mozgatja a lövedéket
            
        }
    }

    private void FixedUpdate()
    {
        
    }
}
