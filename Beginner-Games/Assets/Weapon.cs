using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Weapon : MonoBehaviour
{
    public Weapon2 weapon;
    private Transform aimWeapon;

    private void Awake() {
        aimWeapon = transform.Find("Aim");
    }

    private void Update() {
        Aiming();
        // Shooting();
    }

    private void Aiming() {
        Vector3 mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos); // converts local to worldspace mouse position

        Vector3 aimDirect = (worldPos - transform.position).normalized; // 
        float angle = Mathf.Atan2(aimDirect.y, aimDirect.x) * Mathf.Rad2Deg; // Handles rotation
        aimWeapon.eulerAngles = new Vector3(0, 0, angle); //

        Vector3 Scale = Vector3.one;
        if (angle > 90 || angle < -90) {
            Scale.y = -1f;
        } else {
            Scale.y = +1f;
        }
        aimWeapon.localScale = Scale;
    }

    // private void Shooting() {
        // if(Mouse.current.leftButton.wasPressedThisFrame) {
            // Vector3 mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
            // Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        // }
    // }
    public void OnFire() {
        if(Mouse.current.leftButton.wasPressedThisFrame) {
            weapon.Fire();
        }
    }
    
}
