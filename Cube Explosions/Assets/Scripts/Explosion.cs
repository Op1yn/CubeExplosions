using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _power;
    private float _radius;
    private float _shift = 2f;

    public void Explode(List<Rigidbody> rigidbodys)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_power, transform.position, _radius, _shift);
        }        
    }
}
