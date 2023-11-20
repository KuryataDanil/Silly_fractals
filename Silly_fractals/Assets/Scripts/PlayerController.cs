using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 10;
    public float speed = 5f;
    public float damage= 1;
    public Rigidbody2D rb;
    Vector2 movement;

    private float health;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("PLAYER DEAD");
        Destroy(gameObject);
    }
}
