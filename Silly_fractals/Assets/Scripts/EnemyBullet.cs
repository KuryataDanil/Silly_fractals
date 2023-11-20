using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    PlayerController stats;
    public float damage;

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                stats.TakeDamage(damage);
                DestroyBullet();
                break;
            case "Enemy":
                break;
            default:
                break;
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
