using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.localEulerAngles.y, 0f);



        if (Input.GetKeyDown("c"))
        {
            this.GetComponent<Camera>().orthographicSize -= 1;
        }
        if (Input.GetKeyDown("x"))
        {
            this.GetComponent<Camera>().orthographicSize += 1;
        }

        

    }

}
