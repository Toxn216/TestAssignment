using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs; // Список префабов мобов
    [SerializeField] private Transform spawnPointRight; // Точка спауна
    [SerializeField] private Transform spawnPointLeft; // Точка спауна
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 4f;// Интервал между спаунами

    private void Start()
    {
        // Вызываем SpawnEnemies для каждой точки спауна
        InvokeRepeating("SpawnEnemiesRight", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
        InvokeRepeating("SpawnEnemiesLeft", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnEnemiesRight()
    {
        SpawnEnemies(spawnPointRight);
    }

    void SpawnEnemiesLeft()
    {
        SpawnEnemies(spawnPointLeft);
    }

    private void SpawnEnemies(Transform spawnPoint)
    {
        // Выбираем случайный префаб из списка
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Создаем моба в точке спауна с рандомным отклонением по X(прост)=)
        Vector3 spawnPosition = new Vector3(
            spawnPoint.position.x + Random.Range(-1f, 1f),
            spawnPoint.position.y,
            spawnPoint.position.z
        );
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        
    }
}
