using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Rigidbody> _rigidbodys;

    public void CreateCubes(Cube cube)
    {
        int minimumNumberCubes = 2;
        int maximumNumberCubes = 6;
        int numberCubes = Random.Range(minimumNumberCubes, maximumNumberCubes + 1);

        _rigidbodys = new List<Rigidbody>(numberCubes);

        int reductionRatio = 2;
        Transform transformSelectedCube = cube.transform;

        for (int i = 0; i < numberCubes; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);

            newCube.transform.localScale = new Vector3(transformSelectedCube.localScale.x / reductionRatio, transformSelectedCube.localScale.y / reductionRatio, transformSelectedCube.localScale.z / reductionRatio);
            newCube.SetChanceSeparation(cube.ChanceSeparation / reductionRatio);

            _rigidbodys.Add(newCube.GetComponent<Rigidbody>());
        }
    }

    public List<Rigidbody> GetRigidbodys()
    {
        return _rigidbodys;
    }
}
