using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fegyver : MonoBehaviour
{
    
    public Transform fegyverHelyzet;//innen ind�l a l�ved�k
    public GameObject lovedekobject;//l�ved�k
    public float lovedekSebesseg = 100f;
    public float lovesGyorsasag; // v�ltoz� amivel megadjuk a l�v�sgyorsas�got
    private float kovLoves = 0; //elt�r�lja hogy mikor l�het�nk legk�zelebb
    //A mig 21 es g�pfegyvere 3000-3600 l�v�st adott le mp k�nt(0.02mp k�nt l�tt ki egy l�ved�ket)
    //Ezt l�szertakar�koss�g szempontj�b�l felvittem 0.05 re
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

        if (Input.GetKey(KeyCode.Space) && Time.time > kovLoves) //megn�zi, hogy le van e nyomva a space �s, hogy m�r eltelt e az az id�
        {
            kovLoves = Time.time + lovesGyorsasag;
            var lovedek = Instantiate(lovedekobject, fegyverHelyzet.position, fegyverHelyzet.rotation);//lem�solja(l�trehozza) a l�ved�ket a prefab b�l �s be�ll�tja a megadott helyzetbe
            lovedek.GetComponent<Rigidbody>().velocity = fegyverHelyzet.forward * lovedekSebesseg;//ez mozgatja a l�ved�ket
            
        }
    }

    private void FixedUpdate()
    {
        
    }
}
