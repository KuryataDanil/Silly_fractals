using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float damage;
    private int penetration;
    private int rico;

    void Start()
    {
        PlayerStats stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        EnemiesManager.instance.AddActiveObj(gameObject);
        damage = stats.damage.GetValue;
        rico = stats.ricochet;
        penetration = stats.bulletPenetration;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                other.GetComponent<EnemyStats>().TakeDamage(damage);
                
                if (penetration == 0)
                    DestroyBullet();
                else
                    penetration--;

                break;

            case "Wall":
                if (rico == 0)
                    DestroyBullet();
                else
                    BulletRico();
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

    void BulletRico()
    {
        RaycastHit2D r_c = Physics2D.Raycast((Vector2)transform.position, (Vector2)(transform.rotation * Vector2.right), 20, 1 << 3);
        //Debug.Log(r_c.normal);
        var angle = Vector2.SignedAngle(r_c.normal, -(Vector2)(transform.rotation * Vector2.right));
        var rb = GetComponent<Rigidbody2D>();
        rb.MoveRotation(rb.rotation + 180 - (2 * angle));
        Vector2 v = rb.velocity;
        rb.velocity = Vector2.zero;
        rb.AddForce(Quaternion.Euler(0, 0, 180 - (2 * angle)) * v, ForceMode2D.Impulse);
        rico--;
    }
}
