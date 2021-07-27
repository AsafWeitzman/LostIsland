using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchScript : MonoBehaviour
{
    public GameObject backCam;
    public GameObject fpskCam;

    private void Start()
    {
        fpskCam.SetActive(true);
        backCam.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("1key"))
        {
            fpskCam.SetActive(false);
            backCam.SetActive(true);
        }
        else
        {
            fpskCam.SetActive(true);

        }
    }
}
