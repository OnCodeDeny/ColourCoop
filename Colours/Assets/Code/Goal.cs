using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool RedPresent;
    public bool BluePresent;
    public string SceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            RedPresent = true;
            Debug.Log("Red");
        }
        if (other.gameObject.tag == "Player2")
        {
            BluePresent = true;
            Debug.Log("Blue");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            RedPresent = false;
        }
        if (other.gameObject.tag == "Player2")
        {
            BluePresent = false;
            Debug.Log("Off");
        }
    }

    void FixedUpdate()
    {
        if (RedPresent == true && BluePresent == true)
        {

                StartCoroutine("DelayLoadLevel");
            
        }
    }

    IEnumerator DelayLoadLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneName);

    }

}
