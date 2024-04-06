using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform[] nezet; //nézet valtozo
    [SerializeField] float seb; //sebesség változó

    private int index = 1;
    private Vector3 cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //2 kölönbözõ nézet
        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;

        //A cam et a releváns nézethet irányítja
        cam = nezet[index].position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, cam, Time.deltaTime * seb);
        transform.forward = nezet[index].forward;
    }
}
