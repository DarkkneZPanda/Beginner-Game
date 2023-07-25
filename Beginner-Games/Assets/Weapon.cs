using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Weapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 firePointPos;
        public Vector3 shootPos;
    }
    private Transform aimWeapon;
    private Transform firePoint;
    private Animator animator;
    // public GameObject bullet;
    // public float fireForce = 20f;

    private void Awake() {
        aimWeapon = transform.Find("Aim");
        animator = aimWeapon.GetComponent<Animator>();
        firePoint = aimWeapon.Find("FirePoint");
    }

    private void Update() {
        Aiming();
        Shooting();
    }

    private void Aiming() {
        Vector3 mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos); // converts local to worldspace mouse position

        Vector3 aimDirect = (worldPos - transform.position).normalized; // 
        float angle = Mathf.Atan2(aimDirect.y, aimDirect.x) * Mathf.Rad2Deg; // Handles rotation
        aimWeapon.eulerAngles = new Vector3(0, 0, angle); //
    }

    private void Shooting() {
        if(Mouse.current.leftButton.wasPressedThisFrame) {
            Vector3 mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            OnShoot?.Invoke(this, new OnShootEventArgs {
                firePointPos = firePoint.position, 
                shootPos = worldPos,
            });
        }
    }
}
