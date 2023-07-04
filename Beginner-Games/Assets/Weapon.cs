using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float fireForce = 20f;
    public float rotationSpeed = 100f;
    Rigidbody2D rb;
    Vector3 mousePos;
    Vector2 worldPos;
    Vector2 mouseDirect;
    Transform position;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
    }

    private void Update() {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate() {
        
        mouseDirect = new Vector2(worldPos.x - transform.position.x, worldPos.y - transform.position.y);
        transform.up = mouseDirect;
    }

    public void Fire() {
        GameObject bt = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bt.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
