using UnityEngine;
using System.Threading.Tasks;

public class PlayerStats : MonoBehaviour
{
    private SpriteRenderer sprite_rend;
    private int spriteIndex;
    public Sprite[] spriteArray;

    public int max_health;
    public Stat damage;
    public Stat speed;
    public Stat fire_rate;
    public Stat bulletSpeed;
    public int multyshot;
    public int ricochet;
    public int bulletPenetration;

    public float damageDependsOnHp;
    public float speedUpAfterDamage;

    private int health;

    public int Health { get { return health; } }

    void Start()
    {
        health = max_health;
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {

        health -= Mathf.RoundToInt(dmg);
        ChangeSprite();
        if (health <= 0)
            Die();

        damage.AddModifier(damageDependsOnHp * Mathf.Round(dmg) / max_health);
        if (speedUpAfterDamage == 0)
            return;
        SpeedUpFor2Sec();
    }

    private void ChangeSprite()
    {
        int newSpriteInd = 3;
        switch ((float)health / max_health)
        {
            case > 0.67f:
                newSpriteInd = 0;
                break;
            case > 0.34f:
                newSpriteInd = 1;
                break;
            case > 0:
                newSpriteInd = 2;
                break;
        }
        if (spriteIndex == newSpriteInd)
            return;
        sprite_rend.sprite = spriteArray[newSpriteInd];
        spriteIndex = newSpriteInd;
    }

    void Die()
    {
        Debug.Log(name + " DEAD");
        sprite_rend.sprite = spriteArray[3];

        this.enabled = false;
    }

    public void Heal(int x)
    {
        health = (health + x > max_health) ? max_health : health + x;
        ChangeSprite();

        damage.AddModifier(-damageDependsOnHp * (float)x / max_health);
    }

    private async void SpeedUpFor2Sec()
    {
        float Timer = 0;
        speed.AddModifier(speedUpAfterDamage);
        while (Timer < 2)
        {
            Timer += Time.deltaTime;
            await Task.Yield();
        }
        speed.AddModifier(-speedUpAfterDamage);
    }
}