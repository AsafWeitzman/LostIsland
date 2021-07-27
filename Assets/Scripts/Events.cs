using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Events : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replaygame()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(1);

    }
}
