using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>(2);
    public Transform weaponPoint;

    void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var w = Instantiate(weapons[i], weaponPoint.position, weaponPoint.rotation, weaponPoint);
            w.gameObject.SetActive(false);
            weapons[i] = w;
        }

        ChangeWeapon(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons[0] != null)
        {
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons[1] != null)
        {
            ChangeWeapon(1);
        }
    }

    public void ChangeWeapon(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else weapons[i].gameObject.SetActive(false);
        }
    }
}
