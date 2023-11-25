using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    List<EnemyModifiers.AddModifier> listOfModifiers;
    private GameObject spawner;

    private void Start()
    {
        listOfModifiers = EnemyModifiers.listOfModifiers;
        spawner = EnemiesManager.instance.spawner;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        listOfModifiers.ForEach(x => x());
        StartCoroutine(Blackout());
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0f, -2.5f));
        spawner.GetComponent<EnemySpawner>().SpawnFromList();
    }

    IEnumerator Blackout()
    {
        UnityEngine.UI.Image sprite_rend = GameObject.Find("BlackOut").GetComponent<UnityEngine.UI.Image>();
        Color tempColor = sprite_rend.color;
        while (tempColor.a < 1f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a + 0.05f;
            sprite_rend.color = tempColor;
        }
        while (tempColor.a > 0f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a - 0.10f;
            sprite_rend.color = tempColor;
        }
    }
}