using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Game object Bullet
    public GameObject bt;

    // Position of Bullet
    public Transform firePoint;

    // Force of Bullet
    public float fireForce = 20f;
    
    public void Fire() {
        GameObject bullet = Instantiate(bt, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        
    }
}
