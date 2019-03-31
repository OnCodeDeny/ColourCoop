using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public SpriteRenderer wallColour;
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
        if (wall.layer == 11)
        {
            if ((other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") && Input.GetButtonDown("SwitchColour"))
            {
                wall.layer = 10;
                wallColour.color = new Color(1, 0.3254f, 0.3254f, 1);
            }
        }
        else if (wall.layer == 10)
        {
            if ((other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") && Input.GetButtonDown("SwitchColour"))
            {
                wall.layer = 11;
                wallColour.color = new Color(0.3515f, 0.3254f, 1, 1);
            }
        }
    }
}
