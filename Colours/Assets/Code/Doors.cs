using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [Range(1, 2)]
    public int colorid;
    public string playerTag;
    Collider2D c2d;

    // Start is called before the first frame update
    void Start()
    {
        c2d = GetComponent<Collider2D>();
        if (colorid == 1)
        {
            playerTag = "Player1";
        }
        if (colorid == 2)
        {
            playerTag = "Player2";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != playerTag)
        {

        }
    }
}
