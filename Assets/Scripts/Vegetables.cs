using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class 'Vegetables' is a subclass of 'Food'.
// The RequireComponent attribute ensures that a CapsuleCollider and Rigidbody are attached to any GameObject this script is attached to.
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Vegetables : Food
{
    // Serialized field to set the mass of the vegetables in the Unity Editor.
    [SerializeField]
    private float massV = 2.1f; // Default mass value is set to 1.5.

    // Start is called before the first frame update.
    void Start()
    {
        // Initialize the Rigidbody component inherited from the Food class.
        Rigid = GetComponent<Rigidbody>(); // Assigns the Rigidbody component to the 'Rigid' field from the Food class.

        // Set the mass of the Rigidbody.
        Rigid.mass = massV; // Applies the specified mass value to the Rigidbody's mass property.

        // Set a random angular velocity to the Rigidbody for a rotation effect.
        Rigid.angularVelocity = Random.insideUnitCircle * 2; // Multiplies a random vector inside a unit circle by 2 for angular velocity.
    }
}
