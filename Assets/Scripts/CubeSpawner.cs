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
            cube.Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Clicked -= OnClicked;
        }
    }

    private void OnClicked(Cube cube)
    {
        Split(cube);

        _cubes.Remove(cube);
        cube.Clicked -= OnClicked;
    }

    private void Split(Cube cube)
    {
        int maxChance = 100;
        int randomChance = Random.Range(1, maxChance + 1);

        if (cube.SplitChance >= randomChance)
        {
            SpawnCubes(cube, out List<Rigidbody> rigidbodys);
            _exploder.Explode(rigidbodys);
        }
        else
        {
            _exploder.Explode(_exploder.GetExplodableObjects(cube.transform.position), cube.transform.position, cube.ExplosionMultiplier);
        }
    }

    private List<Rigidbody> SpawnCubes(Cube cube, out List<Rigidbody> rigidbodys)
    {
        int newCubesMin = 2;
        int newCubesMax = 6;
        int newCubesCount = Random.Range(newCubesMin, newCubesMax + 1);
        rigidbodys = new List<Rigidbody>();

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
                newCube.Clicked += OnClicked;
            }
        }

        return rigidbodys;
    }
}