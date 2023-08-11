using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject actualWeapon;
    private float lastSwapTime;
    public float swapCooldown = 10f;

    private void Start()
    {
        Renderer renderer = actualWeapon.GetComponent<Renderer>();
        lastSwapTime = -swapCooldown; 
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Time.time - lastSwapTime >= swapCooldown)
        {
            
            if (other.gameObject.CompareTag("Weapon"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Renderer renderer = actualWeapon.GetComponent<Renderer>();
                    Material aux = renderer.material;
                    renderer.material = other.gameObject.GetComponent<Renderer>().material;
                    other.gameObject.GetComponent<Renderer>().material = aux;
                    lastSwapTime = Time.time;
                }  
            
            }
        }
        
    }
    
}
