using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lovController : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("lovedek")) {
            Destroy(gameObject);
            Debug.Log("Ez mi? hehe");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("lovedek"))
        //{
            Destroy(gameObject);
            Debug.Log("Ez mi? XD mi a fasz");
        //}
    }
}
