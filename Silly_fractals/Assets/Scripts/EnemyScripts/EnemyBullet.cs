using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    PlayerStats stats;
    [HideInInspector]
    public float damage;

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        Destroy(gameObject, lifeTime);
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
            case "Item":
                break;
            case "EnemyBullet":
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
