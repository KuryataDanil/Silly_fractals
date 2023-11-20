using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 5;
    public float damage = 1;
    public float lookRadius = 10f;
    public float shootDistance = 7f;
    public float speed = 0.5f;
    public float coolDown = 0.5f;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    Transform target;
    bool _targeted;

    private float lastShotTime;
    private float health;
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRend;

    void Start()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
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

        if (distance <= lookRadius || health < maxHealth)
            _targeted = true;
    }

    void FaceTarget()
    {
        float angle = Mathf.Atan2(transform.position.y - target.position.y, transform.position.x - target.position.x) * Mathf.Rad2Deg;
        Quaternion lookRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Shoot()
    {
        if (Time.time - lastShotTime < coolDown)
            return;
        lastShotTime = Time.time;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb_b = bullet.GetComponent<Rigidbody2D>();
        rb_b.AddForce((target.position - transform.position).normalized * bulletForce, ForceMode2D.Impulse);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        _spriteRend.color = Color.Lerp(Color.red, Color.white, health / maxHealth);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log(gameObject.name + " DEAD");
        Destroy(gameObject);
    }
}
