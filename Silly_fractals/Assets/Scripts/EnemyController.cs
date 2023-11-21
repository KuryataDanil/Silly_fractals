using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    Transform target;
    bool _targeted;

    private float lookRadius;
    private float shootDistance;
    private float coolDown = 0.5f;
    private float speed;
    private float lastShotTime;
    private Rigidbody2D rb;
    private EnemyStats stats;
    private Quaternion lookRotation;


    void Start()
    {
        stats = GetComponent<EnemyStats>();

        speed = stats.speed;
        coolDown = 1 / stats.fire_rate;
        lookRadius = stats.lookRadius;
        shootDistance = stats.shootDistance;
        bulletPrefab.GetComponent<EnemyBullet>().damage = stats.damage;

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

        if (distance <= lookRadius || stats.max_health > stats.Health)
            _targeted = true;
    }

    void FaceTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        lookRotation = Quaternion.Euler(0, 0, angle);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f));
    }

    void Shoot()
    {
        if (Time.time - lastShotTime < coolDown)
            return;
        lastShotTime = Time.time;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, lookRotation);
        Rigidbody2D rb_b = bullet.GetComponent<Rigidbody2D>();
        rb_b.AddForce((target.position - transform.position).normalized * bulletForce, ForceMode2D.Impulse);
    }
}
