using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : Weapon
{
    [Header("Pistol Config")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Use();
        }
    }

    public override void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
