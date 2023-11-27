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
    public int rico;
    public int bulletPenetration;

    public GameObject[] drop; 

    private float health;

    private void OnEnable()
    {
        health = max_health.GetValue;
        sprite_rend = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    public void TakeDamage(float dmg)
    {
        if (health < 0)
            return;
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
        gameObject.SetActive(false);
        Debug.Log(name + " DEAD");
        Drop();
        EnemiesManager.instance.CheckEnemiesAreDead();
    }

    void Drop()
    {
        PlayerStats p_stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        int n = Random.Range(0, 100);

        if (n < p_stats.moneyLuck)
            DropCoin();

        n = Random.Range(0, 100);
        if (n < p_stats.heartLuck)
            DropHeart();
    }

    void DropCoin()
    {
        int n = Random.Range(0, 100);
        int itemInd = 0;
        switch (n)
        {
            case <8:
                itemInd = 2;
                break;
            case < 40:
                itemInd = 1;
                break;
            default:
                break;

        }
        Instantiate(drop[itemInd], transform.position, transform.rotation);
    }

    void DropHeart()
    {
        int n = Random.Range(0, 100);
        int itemInd = 3;
        if (n < 30)
            itemInd = 4;
        Instantiate(drop[itemInd], transform.position, transform.rotation);
    }

    public float Health { get { return health; } }
}
