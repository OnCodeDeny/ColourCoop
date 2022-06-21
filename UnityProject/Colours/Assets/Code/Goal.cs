using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isGoalReached;
    public int goalID;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (goalID == 1)
        {
            if (other.gameObject.tag == "Player1")
            {
                isGoalReached = true;
                Debug.Log("Red");
            }
        }
        else if (goalID == 2)
        {
            if (other.gameObject.tag == "Player2")
            {
                isGoalReached = true;
                Debug.Log("Blue");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (goalID == 1)
        {
            if (other.gameObject.tag == "Player1")
            {
                isGoalReached = false;
                Debug.Log("Red");
            }
        }
        else if (goalID == 2)
        {
            if (other.gameObject.tag == "Player2")
            {
                isGoalReached = false;
                Debug.Log("Blue");
            }
        }
    }
}
