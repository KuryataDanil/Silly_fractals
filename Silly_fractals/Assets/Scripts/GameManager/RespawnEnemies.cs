using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{
    public GameObject spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            spawner.GetComponent<EnemySpawner>().SpawnFromList();
    }
}
