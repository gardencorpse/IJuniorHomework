using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _targetPrefab;
    [SerializeField] private Transform[] _targetWaypoints;

    private Target _target;

    public Transform TargetTransform => _target.transform;
    public Enemy EnemyPrefab => _enemyPrefab;

    private void Start()
    {
        _target = Instantiate(_targetPrefab, transform);
        _target.Initialize(_targetWaypoints);
    }
}
