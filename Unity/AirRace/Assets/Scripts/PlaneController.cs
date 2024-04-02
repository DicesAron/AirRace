using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float toloeroE = 0.1f;//toloerõ érték
    public float maxToloero = 100f;//Maximális tolóerõ érték
    public float iranyithatosagE = 25f;//mennyira irányítható a gép (minnél nagyobb annál gyorsabban reagál)


    private float toloero;
    private float forgas;
    private float emelkedes;
    private float sik;
    Rigidbody repulo;

    private float iranyithatosag {
        get {
            return (repulo.mass / 10f) * iranyithatosagE; 
        }
    }

    private void Awake()
    {
        repulo = GetComponent<Rigidbody>();//elinduláskor hozzárendeli a repülõ rigidbody át
    }

    private void IranyitasInput() {
        //hozzárendeli az irányítási értékeket az input manager bõl az axis okat a változókhoz
        forgas = Input.GetAxis("Forgas");
        emelkedes = Input.GetAxis("Emelkedes");
        sik = Input.GetAxis("Sik");

        if (Input.GetKey(KeyCode.UpArrow)) toloero += toloeroE;//sebesség növelés
        else if (Input.GetKey(KeyCode.DownArrow)) toloero -= toloeroE;//sebesség csökkentés
        toloero = Mathf.Clamp(toloero, 0f, 100f);//Nem engedi hogy negatív vagy túl nagy legyen a sebesség
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IranyitasInput();


    }

    private void FixedUpdate()
    {
        //A gépre valõ erõhatásokat rárakja a gépre
        repulo.AddForce(transform.right * maxToloero * toloero);
        repulo.AddTorque(transform.up * sik * iranyithatosag);
        repulo.AddTorque(transform.right * emelkedes * iranyithatosag);
        repulo.AddTorque(transform.forward * forgas * iranyithatosag);
    }
}
