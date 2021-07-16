using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    //testing   

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, (float)0.8 * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
