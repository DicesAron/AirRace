using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fegyver : MonoBehaviour
{
    public Transform fegyverHelyzet;//innen inf�l a l�ved�k
    public GameObject lovedekobject;//l�ved�k
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
            var lovedek = Instantiate(lovedekobject, fegyverHelyzet.position, fegyverHelyzet.rotation);//lem�solja(l�trehozza) a l�ved�ket a prefab b�l �s be�ll�tja a megadott helyzetbe
            lovedek.GetComponent<Rigidbody>().velocity = fegyverHelyzet.forward * lovedekSebesseg;//ez mozgatja a l�ved�ket

        }
    }
}
