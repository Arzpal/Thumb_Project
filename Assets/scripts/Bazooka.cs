using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : IWeapon
{
    private int currentAmmo;
    private int totalAmmo;

    public Bazooka(int totalAmmo)
    {
        this.totalAmmo = totalAmmo;
        Reload();
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            // bala
            currentAmmo--;
            if (currentAmmo == 0)
            {
                Reload();
            }
        }
    }

    public void Reload()
    {
        currentAmmo = totalAmmo;
    }
}

