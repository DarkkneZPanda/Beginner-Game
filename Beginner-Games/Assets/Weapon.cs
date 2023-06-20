using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Shoot();
        
        }
    }

    void Shoot() {
        // Shooting Logic
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
