using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MousePauseScreenScript : MonoBehaviour
{
   
    void OnLevelWasLoaded()
    {
        if (!PauseMenuScript.GameIsPaused)
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
