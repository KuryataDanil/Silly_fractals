using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;

public class ItemScript : MonoBehaviour
{
    private PlayerStats stats;

    [SerializeField]
    protected Color color;

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
        if (!PlayerManager.instance.itemsScripts.Any(x => x.GetType() == this.GetType()))
        {
            PlayerManager.instance.itemsScripts.Add(this);
            PlayerManager.instance.itemsSprites.Add(GetComponent<SpriteRenderer>().sprite);
            Inventory.instance.DrawItems();
            PlayerManager.instance.ColorSegment(color);
        }
        Inventory.instance.UpdateText(this);
        UpdateStats(stats);
        gameObject.SetActive(false);
    }



    //---------------------------------------------------------------------//
    protected int count = 0;

    public virtual string GetName { get { return "Name"; } }

    public virtual string GetDescription { get { return "Description"; } }

    public virtual void UpdateStats(PlayerStats stats)
    {
        return;
    }
}