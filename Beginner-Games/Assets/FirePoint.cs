using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirePoint : MonoBehaviour
{
    private bool isFacingRight = true;
    Rigidbody2D rb;
    Vector3 mousePos;
    Vector2 worldPos;
    Vector2 mouseDirect;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate() {
        mouseDirect = new Vector2(worldPos.x - transform.position.x, worldPos.y - transform.position.y);
        transform.up = mouseDirect;
    }

}
