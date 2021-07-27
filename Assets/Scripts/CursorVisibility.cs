using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class CursorVisibility : MonoBehaviour
{
    void OnLevelWasLoaded()
    {
        if (FindObjectOfType<FirstPersonController>() != null)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
}
