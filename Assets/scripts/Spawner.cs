using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private WaitForSeconds _wait;

    private void Start()
    {
        if (_spawnPoints.Count > 0)
        {
            _wait = new WaitForSeconds(_spawnInterval);

            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _spawnInterval)
        {
            elapsedTime += Time.deltaTime / 2;

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            SpawnEnemy(spawnPoint);

            yield return _wait;
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
