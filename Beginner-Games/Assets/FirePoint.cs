using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirePoint : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 mousePos;
    Vector2 worldPos;
    Vector2 mouseDirect;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        mousePos = Mouse.current.position.ReadValue(); // Reads local mouse Postion
        worldPos = Camera.main.ScreenToWorldPoint(mousePos); // converts local to worldspace mouse position
    }

    private void FixedUpdate() {
        mouseDirect = new Vector2(worldPos.x - transform.position.x, worldPos.y - transform.position.y); // Mouse Direction
        transform.up = mouseDirect; 
    }

}
