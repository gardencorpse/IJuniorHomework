using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;

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
        Enemy enemy = Instantiate(_enemy, GetSpawnPosition(), Quaternion.identity);
        enemy.Initialize(GetRotateAngle());
    }

    private Vector3 GetSpawnPosition()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }

    private int GetRotateAngle()
    {
        int maxAngle = 360;
        return Random.Range(0, maxAngle + 1);
    }
}
