using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private int _distance = 15;
    private Ray _ray;
    private Camera _camera;
    private KeyCode leftMouseClick = KeyCode.Mouse0;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
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
                    cube.OnMouseClick();
                }
            }
        }
    }
}
