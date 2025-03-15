using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Colorizer : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));
    }

    private Color GetRandomHoloColor()
    {
        return new Color(
            (float)Random.Range(0, 255),
            (float)Random.Range(0, 255),
            (float)Random.Range(0, 255));
    }
}
