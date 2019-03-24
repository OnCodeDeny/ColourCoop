using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    public GameObject waypoint;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player1") && Input.GetButtonDown("P1Teleport"))
        {
                other.transform.position = new Vector2(waypoint.transform.position.x, waypoint.transform.position.y);
        }

        if ((other.gameObject.tag == "Player2") && Input.GetButtonDown("P2Teleport"))
        {
            other.transform.position = new Vector2(waypoint.transform.position.x, waypoint.transform.position.y);
        }
    }


}
