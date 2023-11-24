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
    }

    #endregion

    public void DrawItems()
    {
        ClearItems();
        int N = PlayerManager.instance.itemsScripts.Count;
        for (int i = 0; i < N; i++)
        {
            CreateEmptyItem();
        }

        for (int i = 0; i < N; i++)
        {
            items[i].GetComponent<Image>().sprite = PlayerManager.instance.itemsSprites[i];
            items[i].GetComponentInChildren<Text>().text = PlayerManager.instance.itemsScripts[i].GetCount.ToString();
        }
    }

    public void UpdateText(ItemScript i_script)
    {
        int i = PlayerManager.instance.itemsScripts.FindIndex(x => x.GetType() == i_script.GetType());
        string txt = items[i].GetComponentInChildren<Text>().text;
        items[i].GetComponentInChildren<Text>().text = (int.Parse(txt)+1).ToString();
        Debug.Log(txt);
    }

    public void CreateEmptyItem()
    {
        GameObject newItem = Instantiate(itemPrefab, transform);

        //HP newheartComp = newheart.GetComponent<HP>();
        //newheartComp.SetImage(HeartStatus.Empty);
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
