using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Stat bulletSpeed;
    private int multiShot;
    private float lastShotTime;
    private Stat fire_rate;

    void Start()
    {
        bulletSpeed = GetComponent<PlayerStats>().bulletSpeed;
        multiShot = GetComponent<PlayerStats>().multyshot;
        fire_rate = GetComponent<PlayerStats>().fire_rate;
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time - lastShotTime < (1 / fire_rate.GetValue))
            return;
        lastShotTime = Time.time;

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
