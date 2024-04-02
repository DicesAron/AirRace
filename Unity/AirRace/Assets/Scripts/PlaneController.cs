using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float toloeroE = 0.1f;//toloer� �rt�k
    public float maxToloero = 100f;//Maxim�lis tol�er� �rt�k
    public float iranyithatosagE = 25f;//mennyira ir�ny�that� a g�p (minn�l nagyobb ann�l gyorsabban reag�l)


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
        repulo = GetComponent<Rigidbody>();//elindul�skor hozz�rendeli a rep�l� rigidbody �t
    }

    private void IranyitasInput() {
        //hozz�rendeli az ir�ny�t�si �rt�keket az input manager b�l az axis okat a v�ltoz�khoz
        forgas = Input.GetAxis("Forgas");
        emelkedes = Input.GetAxis("Emelkedes");
        sik = Input.GetAxis("Sik");

        if (Input.GetKey(KeyCode.UpArrow)) toloero += toloeroE;//sebess�g n�vel�s
        else if (Input.GetKey(KeyCode.DownArrow)) toloero -= toloeroE;//sebess�g cs�kkent�s
        toloero = Mathf.Clamp(toloero, 0f, 100f);//Nem engedi hogy negat�v vagy t�l nagy legyen a sebess�g
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
        //A g�pre val� er�hat�sokat r�rakja a g�pre
        repulo.AddForce(transform.right * maxToloero * toloero);
        repulo.AddTorque(transform.up * sik * iranyithatosag);
        repulo.AddTorque(transform.right * emelkedes * iranyithatosag);
        repulo.AddTorque(transform.forward * forgas * iranyithatosag);
    }
}
