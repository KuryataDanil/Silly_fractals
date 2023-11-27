using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
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

    public void Spawn()
    {
        if (EnemiesManager.instance.Depth == 9 && !EnemiesManager.instance.IsEndless)
        {
            SpawnBoss();
            return;
        }
        SpawnFromList();
        if (enemyCount > EnemiesManager.instance.listOfEnemies.Count)
            SpawnNewEnemies(1);
    }

    public void SpawnBoss()
    {
        PlayerManager.instance.player.GetComponent<Rigidbody2D>().MovePosition(new Vector3(0, -5f, 0));
        boss = Instantiate(boss, new Vector3(0, 1.5f, 0), Quaternion.Euler(0, 0, -90));
        StartCoroutine(EnemyAwake(boss));
    }

    IEnumerator EnemyAwake(GameObject enemy)
    {
        enemy.GetComponent<EnemyController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        enemy.GetComponent<EnemyController>().enabled = true;
    }
}
