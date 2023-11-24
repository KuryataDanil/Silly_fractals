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
        DropCoin();
    }

    void DropCoin()
    {
        int n = Random.Range(0, 100);
        int itemInd = 0;
        switch (n)
        {
            case <= 29:
                itemInd = 0;
                break;
            case <= 35:
                itemInd = 1;
                break;
            case <= 38:
                itemInd = 2;
                break;
            case <= 53:
                itemInd = 3;
                break;
            case <= 68:
                itemInd = 4;
                break;
            default:
                return;
        }
        Instantiate(drop[itemInd], transform.position, transform.rotation);
    }

    public float Health { get { return health; } }
}
