using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;
    private List<GameObject> items;

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
        ClearItems();
    }

    #endregion

    public void DrawItems()
    {
        int N = PlayerManager.instance.itemsScripts.Count;
        CreateEmptyItem();
        items[^1].GetComponent<Image>().sprite = PlayerManager.instance.itemsSprites[^1];
    }

    public void UpdateText(ItemScript i_script)
    {
        int i = PlayerManager.instance.itemsScripts.FindIndex(x => x.GetType() == i_script.GetType());
        string txt = items[i].GetComponentInChildren<Text>().text;
        items[i].GetComponentInChildren<Text>().text = (int.Parse(txt) + 1).ToString();
    }

    public void CreateEmptyItem()
    {
        GameObject newItem = Instantiate(itemPrefab, transform);
        items.Add(newItem);
    }

    public void ClearItems()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        items = new List<GameObject>();
    }
}
