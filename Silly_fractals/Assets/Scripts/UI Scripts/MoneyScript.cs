using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    private PlayerStats stats;

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        PlayerStats.OnMoneyChanged += DrawMoneyCount;
    }

    private void OnDisable()
    {
        PlayerStats.OnMoneyChanged -= DrawMoneyCount;
    }

    private void DrawMoneyCount()
    {
        GetComponent<Text>().text = stats.Money.ToString();
    }
}
