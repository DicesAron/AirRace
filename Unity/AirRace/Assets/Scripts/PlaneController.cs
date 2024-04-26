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
    public bool kintvan;
    AudioSource hajtomu;
    Rigidbody repulo;
    [SerializeField] TextMeshProUGUI kijelzo;
    public GameObject b;
    public GameObject j;
    public GameObject bh;
    public GameObject jh;
    public GameObject s;
    public GameObject bf;
    public GameObject jf;
    public int felfele = 0;
    public bool leszalt = false;
    public int forditas1 = 0;
    public int forditas2 = 0;
    public int forditas3 = 0;
    public int forditas4 = 0;
    public int forditas5 = 0;
    public int forditas6 = 0;
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
        else if (collision.collider.CompareTag("felszallo")&&felfele!=0)
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

        if (repulo.transform.position.y<3 && toloero==0)
        {
            leszalt = true;
        }
        else
        {
            leszalt = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (kintvan==true)
            {
                kintvan = false;
            }
            else
            {
                kintvan = true;
            }
            
           
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (forditas1 < 8)
            {
                b.transform.Rotate(0f, 0f, -1f);
                j.transform.Rotate(0f, 0f, -1f);
                bh.transform.Rotate(0, 0, 0.5f);
                jh.transform.Rotate(0f, 0f, 0.5f);
                forditas1 += 1;
            }
               
                


        }
        else
        {
            if (forditas1 != 0)
            {
                b.transform.Rotate(0f, 0f, 1f);
                j.transform.Rotate(0f, 0f, 1f);
                bh.transform.Rotate(0f, 0f, -0.5f);
                jh.transform.Rotate(0f, 0f,-0.5f);
                forditas1 -= 1;
            }
                
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (forditas2 < 8)
            {
                b.transform.Rotate(0f, 0f, 1f);
                j.transform.Rotate(0f, 0f, 1f);
                bh.transform.Rotate(0, 0, -0.5f);
                jh.transform.Rotate(0f, 0f, -0.5f);
                forditas2 += 1;
            }




        }
        else
        {
            if (forditas2 != 0)
            {
                b.transform.Rotate(0f, 0f, -1f);
                j.transform.Rotate(0f, 0f, -1f);
                bh.transform.Rotate(0f, 0f, 0.5f);
                jh.transform.Rotate(0f, 0f, 0.5f);
                forditas2 -= 1;
            }


        }
        if (Input.GetKey(KeyCode.A))
        {
            if (forditas3 < 8)
            {
                b.transform.Rotate(0f, 0f, -1f);
                j.transform.Rotate(0f, 0f, 1f);
                bh.transform.Rotate(0, 0, -0.5f);
                jh.transform.Rotate(0f, 0f, 0.5f);
                forditas3 += 1;
            }




        }
        else
        {
            if (forditas3 != 0)
            {
                b.transform.Rotate(0f, 0f, 1f);
                j.transform.Rotate(0f, 0f, -1f);
                bh.transform.Rotate(0f, 0f, 0.5f);
                jh.transform.Rotate(0f, 0f, -0.5f);
                forditas3 -= 1;
            }


        }
        if (Input.GetKey(KeyCode.D))
        {
            if (forditas4 < 8)
            {
                b.transform.Rotate(0f, 0f, 1f);
                j.transform.Rotate(0f, 0f, -1f);
                bh.transform.Rotate(0, 0, 0.5f);
                jh.transform.Rotate(0f, 0f, -0.5f);
                forditas4 += 1;
            }




        }
        else
        {
            if (forditas4 != 0)
            {
                b.transform.Rotate(0f, 0f, -1f);
                j.transform.Rotate(0f, 0f, 1f);
                bh.transform.Rotate(0f, 0f, -0.5f);
                jh.transform.Rotate(0f, 0f, 0.5f);
                forditas4 -= 1;
            }


        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (forditas5 < 8)
            {
                s.transform.Rotate(0f, 0.1f, 0f);
                forditas5 += 1;
            }
        }
        else
        {
            if (forditas5 != 0)
            {
                s.transform.Rotate(0f, -0.1f, 0f);
                forditas5 -= 1;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (forditas6 < 8)
            {
                s.transform.Rotate(0f, -0.1f, 0f);
                forditas6 += 1;
            }
        }
        else
        {
            if (forditas6 != 0)
            {
                s.transform.Rotate(0f, 0.1f, 0f);
                forditas6 -= 1;
            }
        }
        if (kintvan==false)
        {
            if (felfele<181)
            {
                bf.transform.Rotate(0.5f, 0f, 0f);
                jf.transform.Rotate(-0.5f, 0f, 0f);
                felfele += 1;
                
            }
            else
            {
                
            }
            
        }
        else
        {
            if (bf.transform.localRotation.x >0)
            {

                bf.transform.Rotate(-0.5f, 0f, 0f);
                jf.transform.Rotate(0.5f, 0f, 0f);
                if (felfele>0)
                {
                    felfele -= 1;
                }
                
            }
            else
            {
                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        kintvan = true;
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
