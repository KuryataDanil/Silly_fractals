using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Table : MonoBehaviour
{
    [HideInInspector]
    public float priceMod = 0;
    [HideInInspector]
    public int minPrice = 2;
    private GameObject item;
    private int price;

    private void OnEnable()
    {
        int n = Random.Range(0, EnemiesManager.instance.trader.GetComponent<Trader>().listOfItemsForSell.Count);
        item = EnemiesManager.instance.trader.GetComponent<Trader>().listOfItemsForSell[n];

        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;

        int max_price = 15;
        if (item.TryGetComponent<HeartScript>(out HeartScript t))
            max_price = 5;

        int r_price = Random.Range(2, max_price + 1);
        price = r_price + Mathf.RoundToInt(r_price * priceMod);

        transform.GetChild(1).GetComponent<TextMeshPro>().text = (price).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && PlayerManager.instance.player.GetComponent<PlayerStats>().Money >= price)
        {
            gameObject.SetActive(false);
            Instantiate(item, transform.position, transform.rotation);
            PlayerManager.instance.player.GetComponent<PlayerStats>().AddMoney(-price);
        }
    }
}
