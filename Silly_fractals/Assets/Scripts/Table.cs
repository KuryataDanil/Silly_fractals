using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{
    [HideInInspector]
    public float priceMod = 0;
    [HideInInspector]
    public int minPrice = 2;
    private GameObject item;
    private int price;
    private ItemScript itemScript;
    private bool isItem;

    private void OnEnable()
    {
        int n = Random.Range(0, EnemiesManager.instance.trader.GetComponent<Trader>().listOfItemsForSell.Count);
        item = EnemiesManager.instance.trader.GetComponent<Trader>().listOfItemsForSell[n];
        Debug.Log(item);

        int max_price = 15;
        if (item.TryGetComponent(out HeartScript t))
        {
            max_price = 5;
            item = Instantiate(item, transform.position, transform.rotation);
            item.GetComponent<HeartScript>().enabled = false;
        }
        else
        {
            isItem = true;
            item = Instantiate(item, transform.position, transform.rotation);
            Debug.Log(item.transform.GetComponentInChildren<MonoBehaviour>() as ItemScript);
            itemScript = item.transform.GetComponentInChildren<MonoBehaviour>() as ItemScript;
            itemScript.ForTrade = true;
        }

        int r_price = Random.Range(2, max_price + 1);
        price = r_price + Mathf.RoundToInt(r_price * priceMod);

        transform.GetChild(0).GetComponent<TextMeshPro>().text = (price).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && PlayerManager.instance.player.GetComponent<PlayerStats>().Money >= price)
        {
            gameObject.SetActive(false);
            if (isItem)
                itemScript.MoveToPlayer(PlayerManager.instance.player.transform);
            else
                item.GetComponent<HeartScript>().enabled = true;

            PlayerManager.instance.player.GetComponent<PlayerStats>().AddMoney(-price);
        }
    }
}
