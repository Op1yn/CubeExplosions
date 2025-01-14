using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _power;
    private float _radius;

    public void Explode(List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_power, transform.position, _radius, 2f);
        }        
    }

}
