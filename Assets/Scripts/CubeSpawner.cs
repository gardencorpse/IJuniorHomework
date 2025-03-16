using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private List<Cube> _cubes;

    private int _divider = 2;
    private Exploder _exploder;

    private void Awake()
    {
        _exploder = new Exploder();
    }

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Clicked += SpawnCube;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Clicked -= SpawnCube;
        }
    }

    private void SpawnCube(Cube cube)
    {
        int maxChance = 100;
        int randomChance = Random.Range(1, maxChance);

        if (cube.SplitChance >= randomChance)
        {
            int newCubesMin = 2;
            int newCubesMax = 6;
            int newCubesCount = Random.Range(newCubesMin, newCubesMax);
            List<Rigidbody> rigidbodys = new List<Rigidbody>();

            for (int i = 0; i < newCubesCount; i++)
            {
                Cube newCube = Instantiate(_prefab, cube.transform.position, Quaternion.identity);
                rigidbodys.Add(newCube.Rigidbody);

                int explosionMultiplier = cube.ExplosionMultiplier + 1;
                int splitChance = cube.SplitChance / _divider;
                Vector3 newScale = new Vector3(
                    cube.transform.localScale.x / _divider,
                    cube.transform.localScale.y / _divider,
                    cube.transform.localScale.z / _divider);

                newCube.Initialize(explosionMultiplier, splitChance, newScale);

                if (newCube != null)
                {
                    _cubes.Add(newCube);
                    newCube.Clicked += SpawnCube;
                }
            }

            _exploder.Explode(rigidbodys);
        }
        else
        {
            _exploder.Explode(_exploder.GetExplodableObjects(cube.transform.position), cube.transform.position, cube.ExplosionMultiplier);
        }

        _cubes.Remove(cube);
        cube.Clicked -= SpawnCube;
    }
}