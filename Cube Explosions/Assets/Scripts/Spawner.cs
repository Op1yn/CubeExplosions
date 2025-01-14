using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Selector _selector;
    private List<Rigidbody> _rigidbodys;

    public event Action<List<Rigidbody>> CreatedNewCubes;

    private void OnEnable()
    {
        _selector.SelectedCube += CreateCube;
    }

    private void OnDisable()
    {
        _selector.SelectedCube -= CreateCube;
    }

    public void CreateCube(Cube cube)
    {
        float minimumNumber = 0;
        float maximumNumber = 100;

        float randomNumber = UnityEngine.Random.Range(minimumNumber, maximumNumber + 1);

        if (randomNumber <= cube.ChanceSeparation)
        {
            int minimumNumberCubes = 2;
            int maximumNumberCubes = 6;
            int numberCubes = UnityEngine.Random.Range(minimumNumberCubes, maximumNumberCubes + 1);

            _rigidbodys = new List<Rigidbody>(numberCubes);

            int reductionRatio = 2;
            Transform transformSelectedCube = cube.transform;

            for (int i = 0; i < numberCubes; i++)
            {
                Cube newCube = Instantiate(_cube, cube.transform.position, Quaternion.identity);

                newCube.transform.localScale = new Vector3(transformSelectedCube.localScale.x / reductionRatio, transformSelectedCube.localScale.y / reductionRatio, transformSelectedCube.localScale.z / reductionRatio);
                newCube.SetChanceSeparation(cube.ChanceSeparation / reductionRatio);

                _rigidbodys.Add(newCube.GetComponent<Rigidbody>());
            }

            CreatedNewCubes += cube.Explode;
            CreatedNewCubes?.Invoke(_rigidbodys);
        }

        CreatedNewCubes -= cube.Explode;
        Destroy(cube.gameObject);
    }
}
