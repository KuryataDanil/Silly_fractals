using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public List<ItemScript> itemsScripts;
    public List<Sprite> itemsSprites;

    public GameObject itemText;

    public GameObject canvas;

    private SpriteRenderer[] segments;
    private int curSeg;

    private void Start()
    {
        segments = player.transform.GetChild(1).GetComponentsInChildren<SpriteRenderer>();
        curSeg = 0;

        UnityEngine.UI.Image sprite_rend = GameObject.Find("BlackOut").GetComponent<UnityEngine.UI.Image>();
        Color tempColor = sprite_rend.color;
        tempColor.a = 1f;
        sprite_rend.color = tempColor;

    }

    public void ColorSegment(Color color)
    {
        if (curSeg >= segments.Length)
            return;

        segments[curSeg].color = color;
        curSeg++;
    }
}
