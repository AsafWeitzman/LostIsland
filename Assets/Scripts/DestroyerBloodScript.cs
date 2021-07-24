using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBloodScript : MonoBehaviour
{
    public float timeToDestroy = 2f;

    public void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
