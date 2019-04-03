using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopup : MonoBehaviour
{
    public GameObject textPrefab;
    [TextArea]
    public string message;
    public float showTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "PurpleSwitch")
        {
            ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        GameObject newText = Instantiate(textPrefab, transform.position, transform.rotation);
        newText.GetComponent<TextMesh>().text = message;
        DestroyTimer.DestroyOnTime(newText, showTime);
    }
}
