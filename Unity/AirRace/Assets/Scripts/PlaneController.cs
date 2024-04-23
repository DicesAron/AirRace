using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlaneController : MonoBehaviour
{
    public float toloeroE = 0.1f;//toloerõ érték
    public float maxToloero = 100f;//Maximális tolóerõ érték
    public float iranyithatosagE = 15f;//mennyira irányítható a gép (minnél nagyobb annál gyorsabban reagál)
    public float felhajtoero = 200f;//változó ami meghatározza, hogy mekkora felhajtó erõt generáll a vadászgep

    private float toloero;
    private float forgas;
    private float emelkedes;
    private float sik;
    AudioSource hajtomu;
    Rigidbody repulo;
    [SerializeField] TextMeshProUGUI kijelzo;
    public GameObject b;
    public GameObject j;
    public GameObject bh;
    public GameObject jh;
    public GameObject s;
    private float iranyithatosag {
        get {
            return (repulo.mass / 10f) * iranyithatosagE; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("palya"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("sikertelen");
        }
    }

    private void Awake()
    {
        repulo = GetComponent<Rigidbody>();//elinduláskor hozzárendeli a repülõ rigidbody át
        hajtomu = GetComponent<AudioSource>();
    }

    private void IranyitasInput() {
        //hozzárendeli az irányítási értékeket az input manager bõl az axis okat a változókhoz
        forgas = Input.GetAxis("Forgas");
        emelkedes = Input.GetAxis("Emelkedes");
        sik = Input.GetAxis("Sik");

        if (Input.GetKey(KeyCode.UpArrow)) toloero += toloeroE;//sebesség növelés
        else if (Input.GetKey(KeyCode.DownArrow)) toloero -= toloeroE;//sebesség csökkentés
        toloero = Mathf.Clamp(toloero, 0f, 100f);//Nem engedi hogy negatív vagy túl nagy legyen a sebesség


        if (Input.GetKey(KeyCode.W))
        {
            
                b.transform.Rotate(0f, 0f, -0.1f);
                b.transform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(b.transform.localEulerAngles.z,0,-7));
                j.transform.Rotate(0f, 0f, -0.1f);
                j.transform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(j.transform.localEulerAngles.z, 0, -7));
                bh.transform.Rotate(0.1f,0 , 0f);
                bh.transform.localEulerAngles = new Vector3(Mathf.Clamp(jh.transform.localEulerAngles.y, -80, -90), - 90 , -90);


        }
        else
        {
            if (b.transform.localRotation.z<0)
            {
                b.transform.Rotate(0f, 0f, 0.2f);
                j.transform.Rotate(0f, 0f, 0.2f);
                bh.transform.Rotate(0f, -0.2f, 0f);
            }
                
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IranyitasInput();
        Kijelzo();
        hajtomu.volume = toloero * 0.001f;
    }

    private void FixedUpdate()
    {
        //A gépre valõ erõhatásokat rárakja a gépre
        repulo.AddForce(transform.right * maxToloero * toloero);
        repulo.AddTorque(transform.up * sik * iranyithatosag);
        repulo.AddTorque(transform.right * emelkedes * iranyithatosag);
        repulo.AddTorque(transform.forward * forgas * iranyithatosag);
        repulo.AddForce(Vector3.up * repulo.velocity.magnitude * felhajtoero);

    }

    private void Kijelzo() {
        kijelzo.text = "Tolóerõ " + toloero.ToString("F0") + "%\n";
        kijelzo.text += "Sebesség " + (repulo.velocity.magnitude*3.6f).ToString("F0") + "km/h\n";
        kijelzo.text += "Magasság " + transform.position.y.ToString("F0") + " m";
    }
}
