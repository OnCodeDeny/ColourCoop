using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer 
{
    public static void DestroyOnTime(GameObject gameObject, float DestroyTime)
    {
        GameObject.Destroy(gameObject, DestroyTime);
    }
}
