using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private PlayerStats stats;
    private GameObject text;

    public bool ForTrade = false;

    [SerializeField]
    protected Color color;

    void Start()
    {
        EnemiesManager.instance.AddActiveObj(gameObject);
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        text = Instantiate(PlayerManager.instance.itemText, PlayerManager.instance.canvas.transform);


        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.position = screenPoint + new Vector2(0, (Camera.main.pixelHeight / 7f));

        text.transform.GetChild(0).GetComponent<Text>().text = GetName;
        text.transform.GetChild(1).GetComponent<Text>().text = GetDescription;

        text.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ForTrade)
            return;
        if (other.tag == "Player")
        {
            MoveToPlayer(other.transform);
        }
    }

    private void OnMouseOver()
    {
        text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }

    public async void MoveToPlayer(Transform target)
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
        PlayerManager.instance.gameObject.GetComponent<AudioSource>().Play();
        Inventory.instance.UpdateText(this);
        UpdateStats(stats);
        StatsHUD.instance.UpdateStatsHUD();
        gameObject.SetActive(false);
        Destroy(text);
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