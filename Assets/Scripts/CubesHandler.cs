using UnityEngine;
using UnityEngine.Pool;

public class CubesHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private ObjectPool<Cube> _cubePool;

    private void Awake()
    {
        
    }
}
