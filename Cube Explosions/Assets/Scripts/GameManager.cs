using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Selector _selector;
    private List<Cube> _cubes;

    public event Action<List<Cube>> CreatedNewCubes;

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

            _cubes = new List<Cube>(numberCubes);

            int reductionRatio = 2;
            Transform transformSelectedCube = cube.transform;

            for (int i = 0; i < numberCubes; i++)
            {
                Cube newCube = Instantiate(_cube, cube.transform.position, Quaternion.identity);

                newCube.transform.localScale = new Vector3(transformSelectedCube.localScale.x / reductionRatio, transformSelectedCube.localScale.y / reductionRatio, transformSelectedCube.localScale.z / reductionRatio);
                newCube.SetChanceSeparation(cube.ChanceSeparation / reductionRatio);

                _cubes.Add(newCube);
            }

            CreatedNewCubes += cube.Explode;
            CreatedNewCubes?.Invoke(_cubes);
        }

        CreatedNewCubes -= cube.Explode;
        Destroy(cube.gameObject);
    }
}
