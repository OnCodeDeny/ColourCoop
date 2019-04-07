using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutTheGame : MonoBehaviour
{
    public GameObject AboutScreen;

    public void ShowInfo()
    {
        Instantiate(AboutScreen);
    }
}
