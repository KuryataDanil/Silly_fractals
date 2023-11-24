using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab;
    private PlayerStats stats;
    private List<HP> hearts = new List<HP>();

    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        DrawHearts();
    }

    private void OnEnable()
    {
        PlayerStats.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerStats.OnPlayerDamaged -= DrawHearts;
    }


    public void DrawHearts()
    {
        CleartHearts();
        int heartsN = stats.max_health / 2 + stats.max_health % 2;
        for (int i = 0; i < heartsN; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < heartsN; i++)
        {
            int heartStatusRemainder = Mathf.Clamp(stats.Health - (i * 2), 0, 2);
            hearts[i].SetImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newheart = Instantiate(heartPrefab, transform);

        HP newheartComp = newheart.GetComponent<HP>();
        newheartComp.SetImage(HeartStatus.Empty);
        hearts.Add(newheartComp);
    }

    public void CleartHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HP>();
    }
}
