using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawnPoint : MonoBehaviour
{
    public float spawnRadius = 5f;

    public bool SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 player_pos = PlayerManager.instance.player.transform.position;
        if (Vector2.Distance(transform.position, player_pos) < 3)
            return false;
        while (true) { 
            Vector3 randomSpawnPoint = GenerateRandomPosition();

            if (Vector2.Distance(randomSpawnPoint, player_pos) > 3 && CheckCollision(randomSpawnPoint))
            {
                Quaternion r_rotarion = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, r_rotarion);
                StartCoroutine(EnemyAwake(enemy));
                EnemiesManager.instance.listOfEnemies.Add(enemy);
                EnemiesManager.instance.listOfStats.Add(enemy.GetComponent<EnemyStats>());
                break;
            }
        }
        return true;
    }

    public bool EnableEnemy(GameObject enemy)
    {
        Vector3 player_pos = PlayerManager.instance.player.transform.position;
        if (Vector2.Distance(transform.position, player_pos) < 3)
            return false;
        while (true)
        {
            Vector2 randomSpawnPoint = GenerateRandomPosition();

            if (Vector2.Distance(randomSpawnPoint, player_pos) > 3 && CheckCollision(randomSpawnPoint))
            {
                enemy.transform.position = randomSpawnPoint;
                enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90) * (new Vector3(0f, -2.5f, enemy.transform.position.z) - enemy.transform.position));
                enemy.SetActive(true);
                StartCoroutine(EnemyAwake(enemy));
                break;
            }
        }
        return true;
    }

    IEnumerator EnemyAwake(GameObject enemy)
    {
        enemy.GetComponent<EnemyController>().enabled = false;
        yield return new WaitForSeconds(1);
        enemy.GetComponent<EnemyController>().enabled = true;
    }

    Vector3 GenerateRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector2 randomPosition = new Vector2(randomCircle.x, randomCircle.y) + (Vector2)transform.position;
        return randomPosition;
    }

    bool CheckCollision(Vector3 position)
    {
        // Проверяем, есть ли коллайдер вблизи новой позиции
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);

        //foreach (Collider2D collider in colliders)
        //{
        //    if (collider.CompareTag("Enemy"))
        //    {
        //        return true;
        //    }
        //}

        return colliders.Length == 0;
    }
}
