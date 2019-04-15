using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private string grabButtonName;
    public bool isGrabbing;
    public GameObject carryStuff;

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

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown(grabButtonName))
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == "Teleporter")
            {
                isGrabbing = true;
                carryStuff = collision.gameObject;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Dragging");
            }
        }
    }
}
