using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerFpsScript : MonoBehaviour
{
    public AudioClip attackSound;
    public float soundIntensity = 5f;
    public LayerMask zombieLayer;
    public float walkEnemyPerceptionRadius = 1f;
    public float sprintEnemyPerceptionRadius = 1.5f;
    public Transform spherecastSpawn;

    public int attackDamage = 30;
    private AudioSource audioSource;
    private FirstPersonController fpsc;
    private SphereCollider sphereCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fpsc = GetComponent<FirstPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        if (fpsc.GetPlayerStealthProfile() == 0)
        {
            sphereCollider.radius = walkEnemyPerceptionRadius;
        }
        else
        {
            sphereCollider.radius = sprintEnemyPerceptionRadius;
        }
        
    }

    // we caan use walk sound insted fire sound
    public void Fire()
    {
        audioSource.PlayOneShot(attackSound);
        animator.SetTrigger("Attack");
        Collider[] zombies = Physics.OverlapSphere(transform.position, soundIntensity, zombieLayer);
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i].GetComponent<AI1Script>().OnAware();
        }

        RaycastHit hit;
        
        if (Physics.SphereCast(spherecastSpawn.position, 0.5f, spherecastSpawn.TransformDirection(Vector3.forward), out hit, zombieLayer)) 
        {
            hit.transform.GetComponent<AI1Script>().OnHit(attackDamage);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<AI1Script>().OnAware();
        }
    }



}
