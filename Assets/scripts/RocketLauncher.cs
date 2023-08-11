using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : IWeapon
{
    private int currentAmmo;
    private int totalAmmo;

    public RocketLauncher(int totalAmmo)
    {
        this.totalAmmo = totalAmmo;
        Reload();
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            
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

