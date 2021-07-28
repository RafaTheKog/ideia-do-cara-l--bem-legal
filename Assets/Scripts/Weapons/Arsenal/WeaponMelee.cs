using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    [Header("Melee Config")]

    public int damage = 20;
    public float attackCoolDown = 0.5f;

    private Collider2D damageArea;

    protected virtual  void Start()
    {
        damageArea = GetComponent<Collider2D>();
    }
}
