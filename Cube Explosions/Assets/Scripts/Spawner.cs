using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Rigidbody> _rigidbodys;

    public List<Rigidbody> CreateCubes(Cube cube)
    {
        int minimumNumberCubes = 2;
        int maximumNumberCubes = 6;
        int numberCubes = Random.Range(minimumNumberCubes, maximumNumberCubes + 1);

        _rigidbodys = new List<Rigidbody>(numberCubes);

        Vector3 sizeAncestorFaces = cube.transform.localScale;

        for (int i = 0; i < numberCubes; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCube.Initialization(cube.ChanceSeparation, sizeAncestorFaces);

            _rigidbodys.Add(newCube.GetComponent<Rigidbody>());
        }

        return _rigidbodys;
    }
}
