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
    }

    public void ColorSegment(Color color)
    {
        if (curSeg >= segments.Length)
            return;

        segments[curSeg].color = color;
        curSeg++;
    }
}
