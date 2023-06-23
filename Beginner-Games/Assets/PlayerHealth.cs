using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    public int currentHealth;
    public int maxHealth;
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
