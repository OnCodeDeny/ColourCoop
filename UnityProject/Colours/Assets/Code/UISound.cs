using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public void PlayUISound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MouseOver");
    }
}
