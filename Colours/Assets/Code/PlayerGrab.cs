using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private string grabButtonName;
    public bool isGrabbing;
    public GameObject carryStuff;

    /*public bool canGrab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Teleporter")
        {
            canGrab = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Teleporter")
        {
            canGrab = false;
        }
    }*/

    private void Start()
    {
        if (gameObject.tag == "Player1")
        {
            grabButtonName = "P1Grab";
        }
        else if (gameObject.tag == "Player2")
        {
            grabButtonName = "P2Grab";
        }
    }

    private void Update()
    {
        if (isGrabbing)
        {
            carryStuff.transform.position = transform.position;
        }
        if (Input.GetButtonUp(grabButtonName))
        {
            isGrabbing = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown(grabButtonName))
        {
            if (collision.gameObject.tag == "Teleporter")
            {
                isGrabbing = true;
                carryStuff = collision.gameObject;
            }
        }
    }
}
