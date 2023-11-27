using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Hatch : MonoBehaviour
{
    List<EnemyModifiers.AddModifier> listOfModifiers;
    private GameObject spawner;
    private GameObject text;
    private string description = "";
    private bool _isOpened = false;
    private Text _desc;

    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    public static event Action OnLevelChanged;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        listOfModifiers = new List<EnemyModifiers.AddModifier>();
        spawner = EnemiesManager.instance.spawner;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        text = Instantiate(PlayerManager.instance.itemText, PlayerManager.instance.canvas.transform);


        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.position = screenPoint + new Vector2(0, (Camera.main.pixelHeight / 7f));

        text.transform.GetChild(0).GetComponent<Text>().text = "На следующем уровне";
        _desc = text.transform.GetChild(1).GetComponent<Text>();
        //listOfModifiers.ForEach(x => AddDescription(x(true)));
        //_desc.text = description;

        text.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (_isOpened && !PauseMenu.GameIsPaused)
            text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isOpened || collision.tag != "Player")
            return;
        _isOpened = false;

        StartCoroutine(Blackout());
    }

    public void TextOff()
    {
        text.SetActive(false);
    }

    private void AddDescription(string s)
    {
        description += s + '\n';
    }

    public void AddModifier(EnemyModifiers.AddModifier modifier)
    {
        if (listOfModifiers.Contains(modifier))
            return;
        listOfModifiers.Add(modifier);
    }

    public void OpenHatch()
    {
        listOfModifiers.ForEach(x => AddDescription(x(true)));
        _desc.text = description;
        if (EnemiesManager.instance.Depth == 8 && !EnemiesManager.instance.IsEndless)
        {
            _desc.text = "???";
            listOfModifiers = new List<EnemyModifiers.AddModifier>();
        }
        StartCoroutine(OpenHatchPLZ());
    }

    IEnumerator OpenHatchPLZ()
    {
        while (Vector2.Distance((Vector2)PlayerManager.instance.player.transform.position, (Vector2)transform.position) <= 4f)
            yield return new WaitForEndOfFrame();
        _isOpened = true;
        spriteRenderer.sprite = sprites[1];
    }

    public void CloseHatch()
    {
        description = "";
        _isOpened = false;
        spriteRenderer.sprite = sprites[0];
        listOfModifiers = new List<EnemyModifiers.AddModifier>();
    }

    IEnumerator Blackout()
    {
        UnityEngine.UI.Image sprite_rend = GameObject.Find("BlackOut").GetComponent<UnityEngine.UI.Image>();
        Color tempColor = sprite_rend.color;

        while (tempColor.a < 1f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a + 0.01f;
            sprite_rend.color = tempColor;
        }

        EnemiesManager.instance.IncDepth();
        OnLevelChanged?.Invoke();
        EnemiesManager.instance.DestroyActiveObjs();
        text.SetActive(false);
        listOfModifiers.ForEach(x => x(false));
        EnemiesManager.instance.CloseHatches();
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0f, -2.5f));
        if (EnemiesManager.instance.Depth == 9 && !EnemiesManager.instance.IsEndless)
            PlayerManager.instance.player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0f, -5f));
        spawner.GetComponent<EnemySpawner>().Spawn();

        while (tempColor.a > 0f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a - 0.01f;
            sprite_rend.color = tempColor;
        }
    }
}