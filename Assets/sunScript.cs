using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 2 * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
