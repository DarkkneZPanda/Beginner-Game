using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float fireForce = 20f;
    Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 worldPos;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        mousePos = Mouse.current.position.ReadValue();   
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate() {
        Vector2 aimDirection = worldPos  - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    public void Fire() {
        GameObject bt = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bt.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
