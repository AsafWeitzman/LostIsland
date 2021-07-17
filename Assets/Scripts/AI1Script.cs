using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


public class AI1Script : MonoBehaviour
{

    public enum WanderType {Random, Waypoint};



    // fps
    public FirstPersonController fpsc;
    //
    
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderRadius = 7f;
    public WanderType wanderType = WanderType.Random;
    public Transform[] waypoints; //array of waypoints is only used when waypoint wandering is selected
    
    private bool isAware = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private Renderer renderer;
    private int waypointIndex = 0;


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
        wanderPoint = RandomWanderPoint();

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
            Wander();
            renderer.material.color = Color.blue;
        }
    }

    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f) 
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1)) 
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                }
            }

        }
    }

    public void OnAware()
    {
        isAware = true;
    }


    public void Wander()
    {
        if (wanderType == WanderType.Random)
        {

            if (Vector3.Distance(transform.position, wanderPoint) < 2f)
            {
                wanderPoint = RandomWanderPoint();
            }
            else
            {
                agent.SetDestination(wanderPoint);
            }
        }
        else
        {
            //waypoint use only if we have more then 1 waypoint !!!!!!!!!!!!!1
            if (Vector3.Distance(waypoints[waypointIndex].position, transform.position) < 2f)
            {
                if (waypointIndex == waypoints.Length - 1)
                {
                    waypointIndex = 0;
                }
                else
                {
                    waypointIndex++;
                }
            }
            else
            {
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }

    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navhit;
        NavMesh.SamplePosition(randomPoint, out navhit, wanderRadius, -1);
        return new Vector3(navhit.position.x, transform.position.y, navhit.position.z);
    }

   

  


}
