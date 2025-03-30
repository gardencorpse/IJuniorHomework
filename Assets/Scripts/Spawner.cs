using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private Coroutine _coroutine;
    private int _delay = 2;

    private void Start()
    {
        _coroutine = StartCoroutine(StartSpawnEnemy());
    }

    private IEnumerator StartSpawnEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        SpawnPoint spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Enemy enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPoint.transform);
        enemy.Initialize(spawnPoint.TargetPosition);
    }
}
