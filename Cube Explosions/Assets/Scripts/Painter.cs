using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private void OnEnable()
    {
        Paint();
    }

    private void Paint()
    {
        float minimumValue = 0f;
        float maximumValue = 1f;

        GetComponent<Renderer>().material.color = new Color(Random.Range(minimumValue, maximumValue), Random.Range(minimumValue, maximumValue), Random.Range(minimumValue, maximumValue));
    }
}
