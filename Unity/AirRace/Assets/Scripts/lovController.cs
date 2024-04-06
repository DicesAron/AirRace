using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lovController : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("lovedek")) {
            Destroy(collision.gameObject);
            Debug.Log("Ez mi?");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Celpont"))
        {
            Destroy(other.gameObject);
            Debug.Log("Ez mi?");
        }
    }
}
