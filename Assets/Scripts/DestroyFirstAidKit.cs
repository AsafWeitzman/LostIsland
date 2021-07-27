using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFirstAidKit : MonoBehaviour
{
    
    public GameObject first_aid_kit;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerFpsScript>().Heal();
            Destroy(first_aid_kit);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

}
