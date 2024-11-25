using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages the player character. It requires a Rigidbody component.
[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    // Private variable for player's life with a public property for access.
    private int life = 5;
    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    // Private variable for player's name with a public property. Default name is "hector".
    private string pName = "hector";
    public string Pname
    {
        get { return pName; }
        set { pName = value; }
    }

    // Public variable for player's speed.
    public Vector3 speed = new Vector3(0, 0, 0);

    // Private variable for player's score with a public property.
    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    // Private variable for player's best score with a public property.
    private int bestScore = 0;
    public int BestScore
    {
        get { return bestScore; }
        set { bestScore = value; }
    }

    // Private variable for player's movement.
    private Vector3 movement;
    Rigidbody rigid;

    // Start is called before the first frame update.
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); // Initialize the Rigidbody component.
    }

    // Update is called once per frame.
    void Update()
    {
        // Handle horizontal input for movement.
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector3(inputX * speed.x, 0, 0);
        RotateGhost(inputX); // Rotate the player based on input direction.
    }

    // FixedUpdate is called every fixed framerate frame.
    private void FixedUpdate()
    {
        rigid.velocity = movement; // Apply movement to the Rigidbody.
    }

    // Rotate the player character based on input direction.
    void RotateGhost(float inputX)
    {
        if (inputX < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0); // Rotate left
        }
        else if (inputX > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate right
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0); // Face forward
        }
    }

    // Handle collisions with different types of food.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("TrashFood"))
        {
            Life -= 1; // Decrease life when colliding with TrashFood.
        }
        if (other.gameObject.CompareTag("HealtlyFood"))
        {
            if (Life < 3)
            {
                Life += 1; // Increase life when colliding with HealtlyFood, if life is less than 5.
            }
            else
            {
                Score += 10; // Otherwise, increase score.
            }
        }
    }
}
