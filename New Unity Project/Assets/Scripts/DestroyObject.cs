using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //destroy the collided game object on collision
        if(collision.gameObject.name == "DestroyObj1" || collision.gameObject.name == "Cube")
        {
            Destroy(collision.gameObject);
        }

        //destroy another object on colliding with the trigger

        if (collision.gameObject.name == "Trigger")
        {
            Destroy(GameObject.FindWithTag("Destroy"));
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger")
        {
            Destroy(GameObject.FindWithTag("Destroy"));
        }
    }
}
