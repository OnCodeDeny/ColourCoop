using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [Range(1, 2)]
    public int colorid;
    public string playerTag;
    public Sprite blueDoor;
    public Sprite redDoor;
    Collider2D c2d;
    //SpriteRenderer wallColour;
    public GameObject particalPrefab;

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
        //wallColour = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SwapColours()
    {
        if (gameObject.layer == 11)
        {
            gameObject.layer = 10;
            GetComponent<SpriteRenderer>().sprite = redDoor;
            //wallColour.color = new Color(1, 0.3254f, 0.3254f, 1);
            GameObject newPartical = Instantiate(particalPrefab, gameObject.transform);
            DestroyTimer.DestroyOnTime(newPartical, 3f);
            return;
        }
        if (gameObject.layer == 10)
        {
            gameObject.layer = 11;
            GetComponent<SpriteRenderer>().sprite = blueDoor;
            //wallColour.color = new Color(0.3515f, 0.3254f, 1, 1);
            GameObject newPartical = Instantiate(particalPrefab, gameObject.transform);
            DestroyTimer.DestroyOnTime(newPartical, 3f);
            return;
        }
    }
}
