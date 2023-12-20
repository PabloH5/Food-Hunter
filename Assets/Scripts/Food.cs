using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class defines the basic behavior for food items.
// It requires both a CapsuleCollider and a Rigidbody component to be attached to the GameObject.
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Food : MonoBehaviour
{
    // Private variable for the Rigidbody component with a public property for access.
    private Rigidbody rigid;
    public Rigidbody Rigid
    {
        get { return rigid; }
        set { rigid = value; }
    }

    // OnCollisionEnter is called when this collider/rigidbody starts touching another rigidbody/collider.
    private void OnCollisionEnter(Collision other)
    {
        // Check if the food collides with an object tagged as "Player" or "Floor".
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject); // Destroy the food object.
        }
    }
}
