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
            case "Wall":
                DestroyBullet();
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
