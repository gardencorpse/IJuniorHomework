using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Cube> _cubes;

    private int _divider = 2;

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.OnClicked += SpawnCube;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.OnClicked -= SpawnCube;
        }
    }

    private void Explode(List<Rigidbody> rigidbodys)
    {
        float _explodeRadius = 25f;
        float _explodePower = 5f;
        float _explodePowerUp = 3f;

        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_explodePower, rigidbody.position, _explodeRadius, _explodePowerUp, ForceMode.Impulse);
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
            int newCubesCount = Random.RandomRange(newCubesMin, newCubesMax);
            List<Rigidbody> rigidbodys = new List<Rigidbody>();

            for (int i = 0; i < newCubesCount; i++)
            {
                GameObject newCubeObject = Instantiate(_prefab, cube.transform.position, Quaternion.identity);
                Cube newCube = newCubeObject.GetComponent<Cube>();
                rigidbodys.Add(newCube.Rigidbody);

                int splitChance = cube.SplitChance / _divider;
                Vector3 newScale = new Vector3(
                    cube.transform.localScale.x / _divider,
                    cube.transform.localScale.y / _divider,
                    cube.transform.localScale.z / _divider);

                newCube.Initialize(splitChance, newScale);

                if (newCube != null)
                {
                    _cubes.Add(newCube);
                    newCube.OnClicked += SpawnCube;
                }
            }

            Explode(rigidbodys);
        }

        _cubes.Remove(cube);
        cube.OnClicked -= SpawnCube;
        Destroy(cube.gameObject);
    }
}
