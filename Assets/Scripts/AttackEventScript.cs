using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEventScript : MonoBehaviour
{
    private PlayerFpsScript pe;

    public void Start()
    {
        pe = GetComponentInParent<PlayerFpsScript>();
    }

    public void DamageEvent()
    {
        pe.Fire();
    }


}
