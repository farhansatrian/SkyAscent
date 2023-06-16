using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if(other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }  
    }
}
