using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    Transform target;
    bool _targeted;

    private float lookRadius;
    private float shootDistance;
    private float coolDown = 0.5f;
    private float speed;
    private float lastShotTime;
    private float multiShot;
    private Rigidbody2D rb;
    private EnemyStats stats;
    private Quaternion lookRotation;


    void OnEnable()
    {
        stats = GetComponent<EnemyStats>();

        speed = stats.speed.GetValue;
        coolDown = 1 / stats.fire_rate.GetValue;
        lookRadius = stats.lookRadius.GetValue;
        shootDistance = stats.shootDistance.GetValue;
        EnemyBullet b_script = bulletPrefab.GetComponent<EnemyBullet>();
        b_script.damage = stats.damage.GetValue;
        b_script.rico = stats.rico;
        b_script.penetration = stats.bulletPenetration;
        multiShot = stats.multyshot;

        rb = GetComponent<Rigidbody2D>();
        target = PlayerManager.instance.player.transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (_targeted)
        {
            rb.MovePosition(rb.position + (Vector2)(target.position - transform.position).normalized * speed * Time.fixedDeltaTime);

            FaceTarget();
            if (distance < shootDistance)
                Shoot();
            return;
        }

        if (distance <= lookRadius || stats.max_health.GetValue > stats.Health)
        {
            _targeted = true;
            Rotate();
        }
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        lookRotation = Quaternion.Euler(0, 0, angle);

        float Timer = 0;
        while (Timer < 0.2)
        {
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f));
            Timer += Time.deltaTime;
        }
    }

    void FaceTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        lookRotation = Quaternion.Euler(0, 0, angle);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f));
    }

    void Shoot()
    {
        if (Time.time - lastShotTime < coolDown)
            return;
        lastShotTime = Time.time;

        Vector3 bulletPos = transform.position + (transform.up * 0.5f);
        Vector3 bulletRot = new Vector3(0, 0, +45);
        for (int i = 0; i <= multiShot; i++)
        {
            bulletPos += -transform.up / (multiShot + 2);
            bulletRot.z -= 90 / (multiShot + 2);
            

            GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.Euler(bulletRot) * transform.rotation);
            Rigidbody2D rb_b = bullet.GetComponent<Rigidbody2D>();
            rb_b.AddForce(Quaternion.Euler(bulletRot) * transform.right.normalized * stats.bulletSpeed.GetValue, ForceMode2D.Impulse);
        }
    }
}
