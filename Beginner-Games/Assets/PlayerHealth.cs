using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    Animator animator;
    void PlayerDamaged(int damage) {
        health -= damage;

        if (health <=0) {
            PlayerDead();
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
    void PlayerDead() {
        animator.SetBool("isDead", true);
    }

    void Destroyed() {
        Destroy(gameObject);
    }
}
