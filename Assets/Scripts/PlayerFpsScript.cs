using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerFpsScript : MonoBehaviour
{
    public GameOverScreenScript GameOverScreen;
    public AudioClip attackSound;
    public float soundIntensity = 5f;
    public LayerMask zombieLayer;
    public float walkEnemyPerceptionRadius = 1f;
    public float sprintEnemyPerceptionRadius = 1.5f;
    public Transform spherecastSpawn;
    public GameObject bloodEffect;
    public int attackDamage = 30;
    public int max_health = 100; //10000
    public int points = 30; // from nir



    private Transform ui_healthbar;
    private int current_health;
    private AudioSource audioSource;
    private FirstPersonController fpsc;
    private SphereCollider sphereCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        audioSource = GetComponent<AudioSource>();
        fpsc = GetComponent<FirstPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
        animator = GetComponentInChildren<Animator>();
        
        
        ui_healthbar = GameObject.Find("HUD/Health/Bar").transform;
        RefreshHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health <= 0)
        {
            Die();
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Input.GetMouseButton(0)  DOING");

            Fire();

        }
        if (fpsc.GetPlayerStealthProfile() == 0)
        {
            sphereCollider.radius = walkEnemyPerceptionRadius;
            animator.SetTrigger("Walk"); //


        }
        else
        {
            sphereCollider.radius = sprintEnemyPerceptionRadius;
            animator.SetTrigger("Sprint"); //

        }
        //ui refreshes
        RefreshHealthBar();
    }

    

    // we can use walk sound insted fire sound
    public void Fire()
    {
        audioSource.PlayOneShot(attackSound);
        animator.SetTrigger("Attack");

        Collider[] zombies = Physics.OverlapSphere(transform.position, soundIntensity, zombieLayer);
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i].GetComponent<AI1Script>().OnAware();
        }

        RaycastHit hit3;

        if (Physics.SphereCast(spherecastSpawn.position, 0.5f, spherecastSpawn.TransformDirection(Vector3.forward), out hit3, zombieLayer))
        {
            hit3.transform.GetComponent<AI1Script>().OnHit(attackDamage);
            Instantiate(bloodEffect, hit3.point, Quaternion.LookRotation(hit3.normal));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<AI1Script>().OnAware();
        }
    }

    private void RefreshHealthBar()
    {
        float t_health_ratio = (float)current_health / (float)max_health;
        if (t_health_ratio >= 0)
        {
            ui_healthbar.localScale = Vector3.Lerp(ui_healthbar.localScale, new Vector3(t_health_ratio, 1, 1), Time.deltaTime * 8f);
            Debug.Log("current health = " + current_health);
        }
        
    }

    //
    
    /*
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            current_health -= 10;
            Debug.Log("current health = "+ current_health);
            RefreshHealthBar();
        }
    }
    */

    //
    public void OnHit(int damage)
    {
        current_health -= damage;
        RefreshHealthBar();
    }

    public void Heal()
    {
        current_health = max_health;
    }
    
    
    public void Die()
    {
        // game over
        GameOverScreen.Setup(points);


    }


    //




}