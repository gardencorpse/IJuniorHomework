using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Colorizer : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
