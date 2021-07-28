using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public static bool gameover, winner;
    public GameObject gameOverPanel;
    public GameObject winingPanel;

    // Start is called before the first frame update
    void Start()
    {
        winner = false;
        gameover = false;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

        }
        if (winner)
        {
            PlayerFpsScript.num_of_comp_missions++; // if the usser won we inc by 1 
            Time.timeScale = 0;
            winingPanel.SetActive(true);
        }
    }
}
