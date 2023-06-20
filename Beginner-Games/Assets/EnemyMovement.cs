using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Start() {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if(target) {
            Vector3 directon = (target.position - transform.position).normalized;
            moveDirection = directon;
        }
    }

    private void FixedUpdate() {
        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
