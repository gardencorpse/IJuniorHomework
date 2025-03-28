using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Cube _prefab;
    private int _repeatRate = 1;
    private ObjectPool<Cube> _pool;
    private int _poolCapacity = 50;
    private int _poolMaxSize = 50;
    private Coroutine _coroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ResetCube(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void Start()
    {
        _coroutine = StartCoroutine(LaunchSpawner());
    }

    private void Spawn()
    {
        _pool.Get();
    }

    private void ResetCube(Cube cube)
    {
        cube.gameObject.transform.position = GetSpawnPosition();
        cube.Rigidbody.angularVelocity = Vector3.zero;
        cube.gameObject.SetActive(true);
        cube.Initialize();
        cube.TimeOuted += ReleaseCube;
    }

    private void ReleaseCube(Cube cube)
    {
        cube.TimeOuted -= ReleaseCube;
        _pool.Release(cube);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 offsetPosition = _platform != null ? _platform.gameObject.transform.position : gameObject.transform.position;
        int hight = 10;
        int maxLength = 10;
        int maxWidth = 3;
        int length = Random.Range(-maxLength, maxLength + 1);
        int width = Random.Range(-maxWidth, maxWidth + 1);

        return new Vector3(
            offsetPosition.x + length,
            offsetPosition.y + hight,
            offsetPosition.z + width);
    }

    private IEnumerator LaunchSpawner()
    {
        var wait = new WaitForSeconds(_repeatRate);

        while (true)
        {
            yield return wait;
            Spawn();
        }
    }
}