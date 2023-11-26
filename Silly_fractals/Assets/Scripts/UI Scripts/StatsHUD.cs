using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    #region Singleton

    public static StatsHUD instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private PlayerStats stats;
    private Text[] text_list;

    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        UpdateStatsHUD();
    }

    public void UpdateStatsHUD()
    {
        text_list = GetComponentsInChildren<Text>();
        text_list[0].text = string.Format("{0:f1}", stats.damage.GetValue);
        text_list[1].text = string.Format("{0:f1}", stats.speed.GetValue);
        text_list[2].text = string.Format("{0:f1}", stats.fire_rate.GetValue);
        text_list[3].text = string.Format("{0:f1}", stats.bulletSpeed.GetValue);
        text_list[4].text = string.Format("{0}%", stats.moneyLuck);
        text_list[5].text = string.Format("{0}%", stats.heartLuck);
    }
}
