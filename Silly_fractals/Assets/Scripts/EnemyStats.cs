using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private SpriteRenderer sprite_rend;

    public int max_health;
    public float damage;
    public float speed;
    public float fire_rate;
    public int multyshot;
    public float lookRadius;
    public float shootDistance;

    private int health;

    private void Start()
    {
        health = max_health;
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {
        health -= Mathf.RoundToInt(dmg);
        sprite_rend.color = Color.Lerp(Color.red, Color.white, (float)health / max_health);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log(name + " DEAD");
        Destroy(gameObject);
    }

    public int Health { get { return health; } }
}
