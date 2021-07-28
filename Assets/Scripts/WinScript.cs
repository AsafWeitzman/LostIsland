using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (PlayerFpsScript.num_of_comp_missions == 2 && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            Debug.Log("miss missions");
        }

    }

    /*
    public void Win()
    {
        SceneManager.LoadScene(5);
    }*/

}
