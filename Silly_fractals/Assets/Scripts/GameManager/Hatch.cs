using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hatch : MonoBehaviour
{
    List<EnemyModifiers.AddModifier> listOfModifiers;
    private GameObject spawner;
    private GameObject text;
    private string description = "";
    private bool _isOpened = false;
    private Text _desc;

    private void Start()
    {
        listOfModifiers = EnemyModifiers.listOfModifiers;
        spawner = EnemiesManager.instance.spawner;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        text = Instantiate(PlayerManager.instance.itemText, PlayerManager.instance.canvas.transform);


        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.position = screenPoint + new Vector2(0, (Camera.main.pixelHeight / 7f));

        text.transform.GetChild(0).GetComponent<Text>().text = "На следующем уровне";
        _desc = text.transform.GetChild(1).GetComponent<Text>();
        listOfModifiers.ForEach(x => AddDescription(x(true)));
        _desc.text = description;

        text.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (_isOpened)
            text.SetActive(true);
    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;


        StartCoroutine(Blackout());
    }

    private void AddDescription(string s)
    {
        description += s + '\n';
    }

    public void OpenHatch()
    {
        _isOpened = true;
    }

    private void CloseHatch()
    {
        _isOpened = false;
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

        text.SetActive(false);
        CloseHatch();
        listOfModifiers.ForEach(x => AddDescription(x(false)));
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0f, -2.5f));
        spawner.GetComponent<EnemySpawner>().SpawnFromList();

        while (tempColor.a > 0f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a - 0.01f;
            sprite_rend.color = tempColor;
        }
    }
}