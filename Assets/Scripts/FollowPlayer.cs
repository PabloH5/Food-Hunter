using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    Vector3 initialPos;
    void Start()
    {
        if (GameObject.Find("Ghost") != null)
        {
            player = GameObject.Find("Ghost");
        }
        else { Debug.LogWarning("The Ghost can't be found."); }
        initialPos = transform.position;
    }

    void Update()
    {
        gameObject.transform.position = UpdatePosition(player);
    }
    Vector3 UpdatePosition(GameObject player)
    {
        Vector3 followPosition;
        if (player != null)
        {
            followPosition = new Vector3(initialPos.x - 100 + player.transform.position.x * 120, initialPos.y + player.transform.position.y, 0.5f);
        }
        else
        {
            Debug.LogWarning("Player can't be found.");
            followPosition = Vector3.zero;
        }
        return followPosition;
    }
}
