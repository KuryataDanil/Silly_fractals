using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifeTime;
    [HideInInspector]
    public float damage;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                other.GetComponent<EnemyStats>().TakeDamage(damage);
                DestroyBullet();
                break;
            case "Player":
                break;
            default:
                DestroyBullet();
                break;
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
