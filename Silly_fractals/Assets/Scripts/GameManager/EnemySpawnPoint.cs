using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawnPoint : MonoBehaviour
{
    public float spawnRadius = 5f;

    public bool SpawnEnemy(GameObject enemyPrefab)
    {
        while (true) { 
            Vector3 randomSpawnPoint = GenerateRandomPosition();
            int n = 0;
            if (CheckCollision(randomSpawnPoint))
            {
                Quaternion rotarion = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90) * (PlayerManager.instance.player.transform.position - randomSpawnPoint));
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, rotarion);
                StartCoroutine(EnemyAwake(enemy));
                EnemiesManager.instance.listOfEnemies.Add(enemy);
                EnemiesManager.instance.listOfStats.Add(enemy.GetComponent<EnemyStats>());
                break;
            }
            n++;
            if (n >= 20)
                return false;
        }
        return true;
    }

    public bool EnableEnemy(GameObject enemy)
    {
        while (true)
        {
            Vector2 randomSpawnPoint = GenerateRandomPosition();
            int n = 0;
            if (CheckCollision(randomSpawnPoint))
            {
                enemy.transform.position = randomSpawnPoint;
                enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90) * (new Vector3(0f, -2.5f, enemy.transform.position.z) - enemy.transform.position));
                enemy.SetActive(true);
                StartCoroutine(EnemyAwake(enemy));
                break;
            }
            n++;
            if (n >= 20)
                return false;
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
