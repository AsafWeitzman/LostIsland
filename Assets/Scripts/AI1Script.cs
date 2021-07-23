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
    public float wanderSpeed = 1.1f;
    public int health = 100;
    public float chaseSpeed = 3f;
    public float viewDistance = 10f;
    public float wanderRadius = 7f;
    public float loseThreshhold = 10f; // time is sec until we lose the player after we stop detecting it
    public WanderType wanderType = WanderType.Random;
    public Transform[] waypoints; //array of waypoints is only used when waypoint wandering is selected
    
    private bool isDetecting = false;
    private bool isAware = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private Renderer renderer;
    private int waypointIndex = 0;
    private Animator animator;
    private float loseTimer = 0;

    private Collider[] ragdollColliders;
    private Rigidbody[] ragdollRigidbodies;

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
        animator = GetComponentInChildren<Animator>();
        wanderPoint = RandomWanderPoint();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Collider col in ragdollColliders)
        {
            if (!col.CompareTag("Zombie"))
            {
                col.enabled = false;
            }
        }
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }

    }

    public void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }
        if (isAware)
        {
            // chase player
            agent.SetDestination(fpsc.transform.position);
            animator.SetBool("Aware", true);
            agent.speed = chaseSpeed;
            //renderer.material.color = Color.red;

            if (!isDetecting)
            {
                loseTimer += Time.deltaTime;
                if(loseTimer >= loseThreshhold)
                {
                    isAware = false;
                    loseTimer = 0;
                }
            }
        }
        else
        {
            Wander();
            animator.SetBool("Aware", false);
            agent.speed = wanderSpeed;
            //renderer.material.color = Color.blue;
        }
        SearchForPlayer();

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
                    else
                    {
                        isDetecting = false;
                    }
                }
                else
                {
                    isDetecting = false;
                }
            }
            else
            {
                isDetecting = false;
            }

        }
        else
        {
            isDetecting = false;
        }
    }

    public void OnAware()
    {
        isAware = true;
        isDetecting = true;
        loseTimer = 0;
    }


    public void Die()
    {
        agent.speed = 0;
        animator.enabled = false;
        
        foreach (Collider col in ragdollColliders) 
        {
            col.enabled = true;
        }

        /*
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }
        */
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            if (!rb.CompareTag("Zombie"))
            {
                rb.isKinematic = false;
            }
        }

            

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


    public void OnHit(int damage)
    {
        health -= damage;
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navhit;
        NavMesh.SamplePosition(randomPoint, out navhit, wanderRadius, -1);
        return new Vector3(navhit.position.x, transform.position.y, navhit.position.z);
    }

   

  


}
