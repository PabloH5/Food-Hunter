using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    private int life = 5;
    public int Life
    {
        get { return life; }
        set { life = value; }
    }
    private string pName = "hector";
    public string Pname
    {
        get { return pName; }
        set { pName = value; }
    }
    public Vector3 speed = new Vector3(0, 0, 0);
    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    private int bestScore = 0;
    public int BestScore
    {
        get { return bestScore; }
        set { bestScore = value; }
    }
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
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TrashFood"))
        {
            Life -= 1;
        }
        if (other.gameObject.CompareTag("HealtlyFood"))
        {
            if (Life < 5)
            {
                Life += 1;
            }
            else { Score += 1; }
        }
    }

}
