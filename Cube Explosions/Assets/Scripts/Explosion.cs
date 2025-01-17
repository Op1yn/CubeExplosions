using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _power = 800;
    [SerializeField] private float _initialRadius = 5;
    private float _shift = 2f;

    public void Explode(List<Rigidbody> rigidbodys)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_power, rigidbody.transform.position, _initialRadius, _shift);
        }
    }

    public void Explode(Cube cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, _initialRadius / cube.transform.localScale.x);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_power / cube.transform.localScale.x, cube.transform.position, _initialRadius / cube.transform.localScale.x);
            }
        }
    }
}
