using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 5f;

    private void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        while (true) { 
            Vector3 randomSpawnPoint = GenerateRandomPosition();

            if (!CheckCollision(randomSpawnPoint))
            {
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
                break;
            }
        }

    }

    Vector3 GenerateRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, randomCircle.y, 0f) + transform.position;
        return randomPosition;
    }

    bool CheckCollision(Vector3 position)
    {
        // Проверяем, есть ли коллайдер вблизи новой позиции
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                return true;
            }
        }

        return false;
    }
}
