using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPos;
    private SpriteRenderer sprite;
    public int number;
    public bool inRightPlace;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = transform.position;
        correctPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition,0.05f);
        
       if(targetPosition == correctPos)
        {
            sprite.color = Color.green;
            inRightPlace = true;
        }
        else
        {
            sprite.color = Color.white;
            inRightPlace = false;
        }
    }
}
