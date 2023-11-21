using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private SpriteRenderer sprite_rend;
    private int spriteIndex;
    public Sprite[] spriteArray;

    public int max_health;
    public float damage;
    public float speed;
    public float fire_rate;
    public int multyshot;

    private int health;

    private void Start()
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
}
