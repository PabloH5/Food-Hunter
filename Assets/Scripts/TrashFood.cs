using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherits from the Food class and represents a specific type of food, presumably "trash" food.
public class TrashFood : Food
{
    // Serialized field to set the drag value in the Unity Editor.
    [SerializeField]
    private float drag = 2.3f; // Default drag value is set to 2.

    // Start is called before the first frame update.
    void Start()
    {
        // Initialize the Rigidbody component inherited from the Food class.
        Rigid = GetComponent<Rigidbody>(); // Assigns the Rigidbody component to the 'Rigid' field from the Food class.

        // Set the drag of the Rigidbody.
        Rigid.drag = drag; // Applies the drag value to the Rigidbody's drag property.

        // Set a random angular velocity to the Rigidbody for rotation effect.
        Rigid.angularVelocity = Random.insideUnitCircle * 4; // Multiplies a random vector inside a unit circle by 4 for angular velocity.
    }
}
