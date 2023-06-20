using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;
    Animator animator;
    PlayerHealth player;
    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Death();
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    void DeathAT() {
        Destroy(gameObject);
    }

    void Death() {
        animator.SetBool("isDead", true);
    }
}
