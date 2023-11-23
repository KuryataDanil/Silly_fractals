using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    private Stat speed;


    void Start()
    {
        speed = GetComponent<PlayerStats>().speed;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed.GetValue * Time.fixedDeltaTime);
    }
}
