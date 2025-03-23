using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Colorizer : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Color _defaultColor;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
    }

    public void ChangeColorToRed()
    {
        _meshRenderer.material.color = Color.red;
    }

    public void ChangeColorToDefault()
    {
        _meshRenderer.material.color = _defaultColor;
    }
}
