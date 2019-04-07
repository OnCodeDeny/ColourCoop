using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnMouseOverButton : MonoBehaviour
{
    public void OnMouseEnter()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MouseOver");
    }
}
