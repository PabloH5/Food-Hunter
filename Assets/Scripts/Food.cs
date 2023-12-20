using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Food : MonoBehaviour
{
    private Rigidbody rigid;
    public Rigidbody Rigid
    {
        get { return rigid; }
        set { rigid = value; }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
