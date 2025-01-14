using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Explosion _explosion;

    [field: SerializeField] public float ChanceSeparation { get; private set; }

    public void Awake()
    {
        _explosion = GetComponent<Explosion>();
    }

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

    public void Explode(List<Rigidbody> rigidbodys)
    {
        _explosion.Explode(rigidbodys);
    }
}
