using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawnPoint : MonoBehaviour
{
    public float spawnRadius = 5f;

    public bool SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 player_pos = PlayerManager.instance.player.transform.position;
        if (Vector2.Distance(transform.position, player_pos) < 4)
            return false;
        while (true) { 
            Vector3 randomSpawnPoint = GenerateRandomPosition();

            if (Vector2.Distance(randomSpawnPoint, player_pos) > 4 && CheckCollision(randomSpawnPoint))
            {
                Quaternion r_rotarion = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, r_rotarion);
                EnemiesManager.instance.listOfEnemies.Add(enemy);
                break;
            }
        }
        return true;
    }

    public bool EnableEnemy(GameObject enemy)
    {
        Vector3 player_pos = PlayerManager.instance.player.transform.position;
        if (Vector2.Distance(transform.position, player_pos) < 4)
            return false;
        while (true)
        {
            Vector2 randomSpawnPoint = GenerateRandomPosition();

            if (Vector2.Distance(randomSpawnPoint, player_pos) > 4 && CheckCollision(randomSpawnPoint))
            {
                Quaternion r_rotarion = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
                enemy.transform.position = randomSpawnPoint;
                enemy.transform.rotation = r_rotarion;
                enemy.SetActive(true);
                break;
            }
        }
        return true;
    }

    Vector3 GenerateRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector2 randomPosition = new Vector2(randomCircle.x, randomCircle.y) + (Vector2)transform.position;
        return randomPosition;
    }

    bool CheckCollision(Vector3 position)
    {
        // ���������, ���� �� ��������� ������ ����� �������
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