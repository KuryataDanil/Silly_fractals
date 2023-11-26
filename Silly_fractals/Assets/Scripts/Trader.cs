using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trader : MonoBehaviour
{
    public List<GameObject> listOfItemsForSell;
    [SerializeField]
    private GameObject trader_menu;
    GameObject[] tables;
    public int cur_tables_count;
    public int max_tables_count;
    private int minPrice = 2;

    private void Awake()
    {
        int n = transform.childCount;
        tables = new GameObject[n];
        for (int i = 0; i < n; i++)
        {
            tables[i] = transform.GetChild(i).gameObject;
            tables[i].SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        if (EnemiesManager.instance.Depth == 1)
        {
            StartTrade();
            return;
        }
        trader_menu.SetActive(true);
        PlayerManager.instance.player.GetComponent<Shooting>().enabled = false;
    }

    private void OnDisable()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    public void AddItem()
    {
        if (cur_tables_count < max_tables_count)
            cur_tables_count++;
        if (cur_tables_count == max_tables_count)
        {
            trader_menu.transform.GetChild(2).gameObject.SetActive(false);
        }

        minPrice += 2;

        StartTrade();
    }

    public void HalfPrice()
    {
        int n = Random.Range(0, tables.Length);
        tables[n].GetComponent<Table>().priceMod = 0.5f;

        minPrice += 2;
        StartTrade();
    }

    public void DontIncMinPrice()
    {
        StartTrade();
    }

    private void StartTrade()
    {
        for (int i = 0; i < cur_tables_count; i++)
        {
            tables[i].GetComponent<Table>().minPrice = minPrice;
        }

        GetComponent<Collider2D>().enabled = false;

        for (int i = 0; i < cur_tables_count; i++)
        {
            tables[i].SetActive(true);
        }

        EnemiesManager.instance.OpenHatches();
    }
}
