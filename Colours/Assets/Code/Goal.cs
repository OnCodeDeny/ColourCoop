using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool RedPresent;
    public bool BluePresent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            RedPresent = true;
            Debug.Log("Red");
        }
        if (other.gameObject.tag == "Player2")
        {
            BluePresent = true;
            Debug.Log("Blue");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            RedPresent = false;
        }
        if (other.gameObject.tag == "Player2")
        {
            BluePresent = false;
            Debug.Log("Off");
        }
    }

    void FixedUpdate()
    {
        if (RedPresent == true && BluePresent == true)
        {
            Debug.Log("Next scene");
        }
    }
}
