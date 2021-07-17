using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


public class AI1Script : MonoBehaviour
{
    // fps
    public FirstPersonController fpsc;
    //
    public float fov = 120f;
    public float viewDistance = 10f;
    private bool isAware = false;
    private NavMeshAgent agent;
    private Renderer renderer;

    // tpsc
    //public MonoBehaviour fpsc;
    //

    public void Start()
    {
        //
        //fpsc = GetComponent<MonoBehaviour>();
        //
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();

    }

    public void Update()
    {
        if (isAware)
        {
            // chase player
            agent.SetDestination(fpsc.transform.position);
            renderer.material.color = Color.red;
        }
        else
        {
            SearchForPlayer();
            renderer.material.color = Color.blue;

        }
    }

    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f) 
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                OnAware();
            }

        }
    }

    public void OnAware()
    {
        isAware = true;
    }


   

  


}
