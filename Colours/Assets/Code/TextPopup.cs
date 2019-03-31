using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public GameObject textPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "PurpleSwitch")
        {
            ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        Instantiate(textPrefab, transform.position, transform.rotation);
    }
}
