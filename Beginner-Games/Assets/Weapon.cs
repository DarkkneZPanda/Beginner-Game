using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private Transform aimWeapon;
    // public GameObject bullet;
    // public float fireForce = 20f;
    Vector3 mousePos;
    Vector3 worldPos;

    private void Awake() {
        aimWeapon = transform.Find("Aim");
    }

    private void Update() {
        mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
        worldPos = Camera.main.ScreenToWorldPoint(mousePos); // converts local to worldspace mouse position

        Vector3 aimDirect = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirect.y, aimDirect.x) * Mathf.Rad2Deg;
        aimWeapon.eulerAngles = new Vector3(0, 0, angle);
        
    }

    public void Fire() {
        
    }
}
