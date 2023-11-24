using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private SpriteRenderer sprite_rend;

    public Stat max_health;
    public Stat damage;
    public Stat speed;
    public Stat fire_rate;
    public int multyshot;
    public Stat lookRadius;
    public Stat shootDistance;
    public Stat bulletSpeed;

    public GameObject[] coins; 

    private float health;

    private void OnEnable()
    {
        health = max_health.GetValue;
        sprite_rend = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ChangeColor();
        if (health <= 0)
            Die();
    }

    private void ChangeColor()
    {
        sprite_rend.color = Color.Lerp(Color.red, Color.white, (float)health / max_health.GetValue);
    }

    void Die()
    {
        Debug.Log(name + " DEAD");
        gameObject.SetActive(false);
        DropCoin();
    }

    void DropCoin()
    {
        int n = Random.Range(0, 100);
        int coin_ind = 0;
        switch (n)
        {
            case <= 40:
                coin_ind = 0;
                break;
            case <= 48:
                coin_ind = 1;
                break;
            case <= 49:
                coin_ind = 2;
                break;
            default:
                return;
        }
        Instantiate(coins[coin_ind], transform.position, transform.rotation);
    }

    public float Health { get { return health; } }
}
