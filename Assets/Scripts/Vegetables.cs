using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Vegetables : Food
{
    [SerializeField]
    private float massV = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Rigid.mass = massV;
        Rigid.angularVelocity = Random.insideUnitCircle * 2;
    }
}
