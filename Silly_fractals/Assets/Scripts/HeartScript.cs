using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HeartScript : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField]
    private int health;

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && stats.Health < stats.max_health)
        {
            GetComponent<Collider2D>().isTrigger = true;
            MoveToPlayer(collision.collider.transform);
        }
    }

    private async void MoveToPlayer(Transform target)
    {
        while (Vector2.Distance((Vector2)transform.position, (Vector2)target.position) > 0.05f)
        {
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)target.position, 3 * Time.fixedDeltaTime);
            await Task.Yield();
        }
        stats.Heal(health);
        gameObject.SetActive(false);
    }
}