using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashFood : Food
{
    [SerializeField]
    private float drag = 2f;
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Rigid.drag = drag;
        Rigid.angularVelocity = Random.insideUnitCircle * 4;
    }

    void Update()
    {

    }
}
