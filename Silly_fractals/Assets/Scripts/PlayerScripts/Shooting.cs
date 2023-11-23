using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Stat bulletSpeed;
    private int multiShot;

    void Start()
    {
        bulletSpeed = GetComponent<PlayerStats>().bulletSpeed;
        multiShot = GetComponent<PlayerStats>().multyshot;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 bulletPos = firePoint.position + (-transform.right * 0.5f);
        for (int i = 0; i <= multiShot; i++)
        {
            bulletPos += transform.right / (multiShot + 2);

            GameObject bullet = Instantiate(bulletPrefab, bulletPos, firePoint.rotation);
            Rigidbody2D rb_b = bullet.GetComponent<Rigidbody2D>();
            rb_b.AddForce(firePoint.right.normalized * bulletSpeed.GetValue, ForceMode2D.Impulse);
        }
    }

    public void IncMultiShot()
    {
        multiShot++;
    }
}
