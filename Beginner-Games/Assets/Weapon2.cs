using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce = 20f;
    public void Fire() {
        GameObject bt = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bt.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
