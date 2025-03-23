using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private int _distance = 15;
    private Exploder _exploder;
    private Ray _ray;
    private Camera _camera;
    private KeyCode leftMouseClick = KeyCode.Mouse0;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _exploder = new Exploder();
    }

    private void Update()
    {
        if (Input.GetKeyDown(leftMouseClick))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, _distance))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.IsSplit())
                    {
                        //_cubeSpawner.SpawnCubes(cube, out List<Rigidbody> rigidbodys);
                        //_exploder.Explode(rigidbodys);
                    }
                    else
                    {
                        _exploder.Explode(cube.transform.position, cube.ExplosionMultiplier);
                    }

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}
