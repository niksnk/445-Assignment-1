using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMechanic : MonoBehaviour
{
    // strength required for character to push objects
    float strength = 5f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //if there is no rigidbody on the object we dont push
        if (body == null || body.isKinematic) return;

        //if the object is below character, dont push as well
        if (hit.moveDirection.y < -0.3) return;

        if (body.gameObject.name == "Cube" || (body.gameObject.name == "DestroyObj1")) return;

        //pushing objects to sides, not up and down

        Vector3 push = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        //multiply character movement speed with the push strength of the character instantiated above
        body.velocity = push * strength;
    }
}
