using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFpsScript : MonoBehaviour
{
    public AudioClip shootSound;
    public float soundIntensity = 5f;
    public LayerMask zombieLayer;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }

    // we caan use walk sound insted fire sound
    public void Fire()
    {
        audioSource.PlayOneShot(shootSound);
        Collider[] zombies = Physics.OverlapSphere(transform.position, soundIntensity, zombieLayer);
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i].GetComponent<AI1Script>().OnAware();
        }
    }




}
