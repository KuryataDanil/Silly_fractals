using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawnPoint : MonoBehaviour
{
    public float spawnRadius = 5f;

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        while (true) { 
            Vector3 randomSpawnPoint = GenerateRandomPosition();

            if (CheckCollision(randomSpawnPoint))
            {
                Quaternion r_rotarion = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, r_rotarion);
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
