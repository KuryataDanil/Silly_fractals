using UnityEngine;
using System.Threading.Tasks;
using System;

public class PlayerStats : MonoBehaviour
{
    private SpriteRenderer sprite_rend;
    private int spriteIndex;
    public Sprite[] spriteArray;

    [SerializeField]
    private int money;

    public int max_health;

    public Stat damage;
    public Stat speed;
    public Stat fire_rate;
    public Stat bulletSpeed;
    public int moneyLuck;
    public int heartLuck;

    public int multyshot;
    public int ricochet;
    public int bulletPenetration;

    public float damageDependsOnHp;
    public float speedUpAfterDamage;
    public int dashCooldown;
    public int lifes;

    private int health;

    private bool _invincible;
    private int _invincible_timer;

    public int Health { get { return health; } }
    public int Money { get { return money; } }

    public static event Action OnPlayerDamaged;
    public static event Action OnMoneyChanged;

    void Awake()
    {
        health = max_health;
        sprite_rend = GetComponent<SpriteRenderer>();
    }
    
    public void TakeDamage(float dmg)
    {
        if (_invincible)
            return;
        InvincibleTime();


        health -= Mathf.RoundToInt(dmg);
        OnPlayerDamaged?.Invoke();
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
        if (lifes <= 0)
        {
            Debug.Log(name + " DEAD");
            sprite_rend.sprite = spriteArray[3];
        }
        lifes--;
        max_health = 2;
        health = 2;
    }

    public void Heal(int x)
    {
        health = (health + x > max_health) ? max_health : health + x;
        OnPlayerDamaged?.Invoke();
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

    private async void InvincibleTime()
    {
        var x = GetComponent<Animator>();
        x.SetBool("invincible", true);
        _invincible = true;
        float Timer = 0;
        while (Timer < 1.5)
        {
            Timer += Time.deltaTime;
            await Task.Yield();
        }
        _invincible = false;
        x.SetBool("invincible", false);
    }

    public void AddMoney(int money)
    {
        this.money += money;
        OnMoneyChanged?.Invoke();
    }
}