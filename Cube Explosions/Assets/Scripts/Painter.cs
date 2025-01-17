using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        Paint();
    }

    private void Paint()
    {
        float minimumValue = 0f;
        float maximumValue = 1f;

        _renderer.material.color = new Color(Random.Range(minimumValue, maximumValue), Random.Range(minimumValue, maximumValue), Random.Range(minimumValue, maximumValue));
    }
}
