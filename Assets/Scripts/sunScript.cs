using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunScript : MonoBehaviour
{
    //testing   
    public GameObject zombie = null;
    public bool flag = false;

    //
    private float nextActionTime = 2f;
    public float period = 3f;
    //

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 5 * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        if (transform.rotation.x > 0)
        {
            //
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                // execute block of code here
                InvokeRepeating("CreateZombies", 1.0f, 10f);
                flag = true;

            }
            
            //
            //InvokeRepeating("CreateZombies", 1.0f, 5f);
        }
        /*
        if (flag)
        {
            DestroyZombies();
        }*/



    }


    void CreateZombies()
    {
        Debug.Log("night");
        //GameObject instance = Instantiate(zombie);

        float vec_x = Random.Range(1280f, 1290f);
        float vec_y = 195f;
        float vec_z = Random.Range(1280f, 1290f);


        //instance = Instantiate(zombie, new Vector3(vec_x, vec_y, vec_z), new Quaternion(0,0,0,0));
        Instantiate(zombie, new Vector3(vec_x, vec_y, vec_z), new Quaternion(0, 0, 0, 0));

    }

    void DestroyZombies()
    {
        while (zombie!=null)
        {
            Destroy(zombie);
        }
        flag = false;


        /*
        if (zombie != null)
        {
            Destroy(zombie);
        }
        else
        {
            Debug.Log("no zombies");

        }
        */

    }

}
