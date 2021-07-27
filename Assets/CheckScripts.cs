using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (MouseController.coins == 5)
        {
            playManager.winner = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Obstacle")
        {
            playManager.gameover = true;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
}
