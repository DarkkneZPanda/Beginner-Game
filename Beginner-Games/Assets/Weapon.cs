using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float fireForce = 20f;

    public void Fire() {
        GameObject bt = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bt.GetComponent<Rigidbody2D>().AddForce(firePoint.up  * fireForce, ForceMode2D.Impulse);
    }
    
}
