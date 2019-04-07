using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    //private Renderer rend;
    SpriteRenderer rend;
    Color startColor;
    public Color enabledColor;
    public float lerpTimer;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
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
            StartCoroutine(FlashColours());
        }

    }

    IEnumerator FlashColours()
    {
        //rend.color = enabledColor;
        timer = 0;
        while(timer < lerpTimer)
        {
            timer += Time.deltaTime;
            rend.color = Color.Lerp(enabledColor, startColor, (timer/lerpTimer));
            yield return null;
        }
        //rend.color = startColor;
    }
}
