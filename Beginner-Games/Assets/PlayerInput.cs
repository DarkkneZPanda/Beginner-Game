using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 150f;
    private bool isFacingRight = true;
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    


    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();  

    }
   private void FixedUpdate() {
  

    // # 1
    // rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

    // # 2 works with Linear Drag
    // if(movementInput.x != || movementInput.y != 0) {
       // rb.velocity = movementInput * moveSpeed;
    // }

    // # 3 works with Linear Drag
    rb.AddForce(movementInput * moveSpeed);
    // Vector2 aimDirection = mousePosition - rb.position;
    // float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x);
    // float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    // rb.rotation = aimAngle;

    if (movementInput.x < 0 && isFacingRight) {
      Flip();
    } else if (movementInput.x > 0 && !isFacingRight) {
      Flip();
    }
     
   }

  void OnMove(InputValue movementValue) {
      movementInput = movementValue.Get<Vector2>();
      if (movementInput.x != 0 || movementInput.y != 0) {
        animator.SetBool("isMoving", true);
      } else {
        animator.SetBool("isMoving", false);
      }
   }

  private void Flip() {
    isFacingRight = !isFacingRight;

    transform.Rotate(0f, 180f, 0f);
  }

  void OnFire() {
    
  }

  



}
