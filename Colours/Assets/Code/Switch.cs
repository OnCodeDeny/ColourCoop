using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    //private Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player1" && Input.GetButtonDown("P1Teleport")) || (other.gameObject.tag == "Player2" && Input.GetButtonDown("P2Teleport")))
        {
            wall.GetComponent<Doors>().SwapColours();
        }

    }
}
