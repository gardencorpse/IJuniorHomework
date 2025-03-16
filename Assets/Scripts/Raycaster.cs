using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private int _distance = 15;
    private Ray _ray;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(_ray, _distance);

            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.TryGetComponent(out Cube cube))
                {
                    cube.OnMouseClick();
                }
            }
        }
    }
}
