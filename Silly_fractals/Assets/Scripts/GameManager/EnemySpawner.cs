using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private EnemySpawnPoint[] spawnPoints;

    public int enemyCount;

    private void Start()
    {
        spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
    }

    public void FirstSpawn()
    {
        SpawnNewEnemies(enemyCount);
    }

    public void SpawnNewEnemies(int n)
    {
        for (var i = 0; i < n; i++)
        {
            GameObject r_enemy = enemies[Random.Range(0, enemies.Length)];
            bool f = true;
            while (f)
            {
                EnemySpawnPoint r_sPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                f = !r_sPoint.SpawnEnemy(r_enemy);
            }
        }
    }
    public void SpawnFromList()
    {
        var lst = EnemiesManager.instance.listOfEnemies;
        for (var i = 0; i < lst.Count; i++)
        {
            bool f = true;
            while (f)
            {
                EnemySpawnPoint r_sPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                f = !r_sPoint.EnableEnemy(lst[i]);
            }
        }
    }

}
