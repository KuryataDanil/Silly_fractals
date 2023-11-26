using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float damage;

    void Start()
    {
        EnemiesManager.instance.AddActiveObj(gameObject);
        damage = PlayerManager.instance.player.GetComponent<PlayerStats>().damage.GetValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                other.GetComponent<EnemyStats>().TakeDamage(damage);
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
        EnemiesManager.instance.RemoveActiveObj(gameObject);
        Destroy(gameObject);
    }
}
