using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public IWeapon currentWeapon;
    public Transform firePoint;

    private void Start()
    {
        currentWeapon = new Bazooka(10);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.Shoot();
        }

        if (Input.GetButton("Fire2"))
        {
            
        }
    }
}

