using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [field: SerializeField] public float ChanceSeparation { get; private set; }

    public void SetChanceSeparation(float value)
    {
        if (value > 0)
        {
            ChanceSeparation = value;
        }
        else
        {
            ChanceSeparation = 0;
        }
    }
}
