using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lovController : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Celpont")) {
            Destroy(gameObject);
            Debug.Log("Ez mi? hehe");
        }
    }

    
}
