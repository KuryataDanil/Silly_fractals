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
        Debug.Log(spawnPoints.Length);
        SpawnNewEnemies(enemyCount);
    }

    public void SpawnNewEnemies(int n)
    {
        for (var i = 0; i < n; i++)
        {
            EnemySpawnPoint r_sPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject r_enemy = enemies[Random.Range(0, enemies.Length)];
            r_sPoint.SpawnEnemy(r_enemy);
        }
    }
    public void SpawnFromList()
    {
        var lst = EnemiesManager.instance.listOfEnemies;
        for (var i = 0; i < lst.Count; i++)
        {
            EnemySpawnPoint r_sPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            r_sPoint.EnableEnemy(lst[i]);
        }
    }

}
