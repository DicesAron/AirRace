using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlaneController : MonoBehaviour
{
    public float toloeroE = 0.1f;//toloer� �rt�k
    public float maxToloero = 100f;//Maxim�lis tol�er� �rt�k
    public float iranyithatosagE = 15f;//mennyira ir�ny�that� a g�p (minn�l nagyobb ann�l gyorsabban reag�l)
    public float felhajtoero = 200f;//v�ltoz� ami meghat�rozza, hogy mekkora felhajt� er�t gener�ll a vad�szgep

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
        repulo = GetComponent<Rigidbody>();//elindul�skor hozz�rendeli a rep�l� rigidbody �t
        hajtomu = GetComponent<AudioSource>();
    }

    private void IranyitasInput() {
        //hozz�rendeli az ir�ny�t�si �rt�keket az input manager b�l az axis okat a v�ltoz�khoz
        forgas = Input.GetAxis("Forgas");
        emelkedes = Input.GetAxis("Emelkedes");
        sik = Input.GetAxis("Sik");

        if (Input.GetKey(KeyCode.UpArrow)) toloero += toloeroE;//sebess�g n�vel�s
        else if (Input.GetKey(KeyCode.DownArrow)) toloero -= toloeroE;//sebess�g cs�kkent�s
        toloero = Mathf.Clamp(toloero, 0f, 100f);//Nem engedi hogy negat�v vagy t�l nagy legyen a sebess�g


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
        //A g�pre val� er�hat�sokat r�rakja a g�pre
        repulo.AddForce(transform.right * maxToloero * toloero);
        repulo.AddTorque(transform.up * sik * iranyithatosag);
        repulo.AddTorque(transform.right * emelkedes * iranyithatosag);
        repulo.AddTorque(transform.forward * forgas * iranyithatosag);
        repulo.AddForce(Vector3.up * repulo.velocity.magnitude * felhajtoero);

    }

    private void Kijelzo() {
        kijelzo.text = "Tol�er� " + toloero.ToString("F0") + "%\n";
        kijelzo.text += "Sebess�g " + (repulo.velocity.magnitude*3.6f).ToString("F0") + "km/h\n";
        kijelzo.text += "Magass�g " + transform.position.y.ToString("F0") + " m";
    }
}
