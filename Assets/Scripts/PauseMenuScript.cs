using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class PauseMenuScript : MonoBehaviour
{



    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject miniMapUI;
    public GameObject healthBarUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        //asaf
        /*
        if (FindObjectOfType<FirstPersonController>() != null)
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;

        }
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        */

        //


        miniMapUI.SetActive(true);
        healthBarUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {

        //asaf
        /*
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        */

        //
        miniMapUI.SetActive(false);
        healthBarUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit...");

        Application.Quit();

    }

}
