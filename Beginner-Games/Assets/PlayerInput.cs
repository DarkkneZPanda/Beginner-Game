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
    // Transform Weap = transform.Find("Weapon");
    // Weap.localPosition = new Vector3(2.75f, 0.65f, 0f);
    // # 1
    // rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

    // # 2 works with Linear Drag
    // if(movementInput.x != || movementInput.y != 0) {
       // rb.velocity = movementInput * moveSpeed;
    // }

    // # 3 works with Linear Drag
    rb.AddForce(movementInput * moveSpeed);
    if(movementInput.x > 0 && !isFacingRight) {
      Flip();
    } else if(movementInput.x < 0 && isFacingRight) {
      Flip();
    }
   }

 public void OnMove(InputValue movementValue) {
      movementInput = movementValue.Get<Vector2>();
   }

  public void Flip() {
    isFacingRight = !isFacingRight;

    transform.Rotate(0f, 180f, 0f);
  }

  



}
