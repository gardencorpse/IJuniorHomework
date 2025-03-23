using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    private int _repeatRate = 1;
    private ObjectPool<Cube> _pool;
    private int _poolCapacity = 15;
    private int _poolMaxSize = 50;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void ActionOnGet(Cube cube)
    {
        cube.gameObject.transform.position = GetSpawnPosition();
        cube.Rigidbody.angularVelocity = Vector3.zero;
        cube.gameObject.SetActive(true);

    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.0f, _repeatRate);
        _pool.Get();
    }

    private void Spawn()
    {
        Instantiate(_prefab, GetSpawnPosition(), Quaternion.identity);
    }

    private void ReleaseCube(Cube cube)
    {
        _pool.Release(cube);
    }

    private Vector3 GetSpawnPosition()
    {
        int hight = 10;
        int maxLength = 10;
        int maxWidth = 3;
        int length = Random.Range(-maxLength, maxLength + 1);
        int width = Random.Range(-maxWidth, maxWidth + 1);

        return new Vector3(length, hight, width);
    }
}