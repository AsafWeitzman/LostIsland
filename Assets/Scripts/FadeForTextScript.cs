using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeForTextScript : MonoBehaviour
{

    public Text welcomeText;
    public float fadeSpeed = 5;
    public bool enterance = false;      

    // Start is called before the first frame update
    void Start()
    {
        welcomeText.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterance = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterance = false;
        }

    }

    private void ColorChange()
    {
        if (enterance)
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.white, fadeSpeed * Time.deltaTime);
        }
        else
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }


}
