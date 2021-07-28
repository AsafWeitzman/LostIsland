using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPauseForFPSScript : MonoBehaviour
{

    
    void  Update()
    {
        isPaused();
    }

    public bool isPaused()
    {
        if (PauseMenuScript.GameIsPaused)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
