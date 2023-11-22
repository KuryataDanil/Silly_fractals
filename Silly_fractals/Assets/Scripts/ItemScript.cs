using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ItemScript : MonoBehaviour
{
    private PlayerStats stats;

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MoveToPlayer(other.transform);
        }
    }

    private async void MoveToPlayer(Transform target)
    {
        while (Vector2.Distance((Vector2)transform.position, (Vector2)target.position) > 0.05f)
        {
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)target.position, 3 * Time.fixedDeltaTime);
            await Task.Yield();
        }
        UpdateStats(stats);
        gameObject.SetActive(false);
    }



    //---------------------------------------------------------------------//
    protected int count = 0;

    public void IncCount()
    {
        count++;
    }

    public int GetCount { get { return count; } }

    public virtual string GetName { get { return "Name"; } }

    public virtual string GetDescription { get { return "Description"; } }

    public virtual void UpdateStats(PlayerStats stats)
    {
        return;
    }
}