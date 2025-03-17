using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints; 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            if (_spawnPoints.Count > 0)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
                SpawnEnemy(spawnPoint);
            }
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.SetDirection(spawnPoint.forward);
    }
}
