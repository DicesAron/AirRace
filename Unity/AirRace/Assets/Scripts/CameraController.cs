using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //nézet valtozo


    public float kameramozgas = 0.125f;
    private Vector3 cam;
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
        Vector3 campoz = target.position + cam;
        Vector3 poz = Vector3.Lerp(transform.position, campoz, kameramozgas);
        transform.position = poz;
    }
}
