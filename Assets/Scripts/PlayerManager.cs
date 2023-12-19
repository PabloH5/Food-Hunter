using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    public int life = 5;
    public Vector3 speed = new Vector3(0, 0, 0);

    private Vector3 movement;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector3(inputX * speed.x, 0, 0);
        Debug.Log(inputX);
        RotateGhost(inputX);
    }

    private void FixedUpdate()
    {
        rigid.velocity = movement;
    }
    void RotateGhost(float inputX)
    {
        if (inputX < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (inputX > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else { gameObject.transform.rotation = Quaternion.Euler(0, 180, 0); }
    }
}
