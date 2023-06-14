using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 150f;
    Vector2 movementInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

   private void FixedUpdate() {

    // # 1
    // rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

    // # 2 works with Linear Drag
    // if(movementInput.x != || movementInput.y != 0) {
       // rb.velocity = movementInput * moveSpeed;
    // }

    // # 3 works with Linear Drag
     rb.AddForce(movementInput* moveSpeed);
   }

   void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
   }
}
