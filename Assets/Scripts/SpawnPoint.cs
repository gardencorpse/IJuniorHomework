using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target targetPrefab;
    [SerializeField] private Transform[] _targetWaypoints;

    private Target target;

    public Transform TargetPosition => target.transform;
    public Enemy EnemyPrefab => _enemyPrefab;

    private void Start()
    {
        target = Instantiate(targetPrefab, transform);
        target.Initialize(_targetWaypoints);
    }
}
