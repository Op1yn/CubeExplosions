using System.Collections.Generic;
using UnityEngine;

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

    public void Explode(List<Cube> cubes)
    {
        _explosion.Explode(cubes);
    }
}
