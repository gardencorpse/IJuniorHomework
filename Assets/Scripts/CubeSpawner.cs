using System.Collections.Generic;
using UnityEngine;

//CubeClickHandle
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public void SpawnCubes(Cube cube, out List<Rigidbody> rigidbodys)
    {
        int _chanceDivider = 2;
        int _scaleDivider = 2;
        int newCubesMin = 2;
        int newCubesMax = 6;
        int newCubesCount = Random.Range(newCubesMin, newCubesMax + 1);
        rigidbodys = new List<Rigidbody>();

        for (int i = 0; i < newCubesCount; i++)
        {
            Cube newCube = Instantiate(_prefab, cube.transform.position, Quaternion.identity);
            rigidbodys.Add(newCube.Rigidbody);

            int explosionMultiplier = cube.ExplosionMultiplier + 1;
            int splitChance = cube.SplitChance / _chanceDivider;
            Vector3 newScale = new Vector3(
                cube.transform.localScale.x / _scaleDivider,
                cube.transform.localScale.y / _scaleDivider,
                cube.transform.localScale.z / _scaleDivider);

            newCube.Initialize(explosionMultiplier, splitChance, newScale);
        }
    }
}