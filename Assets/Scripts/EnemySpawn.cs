using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs; // ������ �������� �����
    [SerializeField] private Transform spawnPointRight; // ����� ������
    [SerializeField] private Transform spawnPointLeft; // ����� ������
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 4f;// �������� ����� ��������

    private void Start()
    {
        // �������� SpawnEnemies ��� ������ ����� ������
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
        // �������� ��������� ������ �� ������
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // ������� ���� � ����� ������ � ��������� ����������� �� X(�����)=)
        Vector3 spawnPosition = new Vector3(
            spawnPoint.position.x + Random.Range(-1f, 1f),
            spawnPoint.position.y,
            spawnPoint.position.z
        );
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        
    }
}
