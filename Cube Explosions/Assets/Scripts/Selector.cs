using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private const int LeftMouseButton = 0;

    private Camera _mainCamera;
    private float _rayLength = 100;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        MakeChoice();
    }

    private void MakeChoice()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (CheckPossibilitySeparation(cube))
                    {
                        _spawner.CreateCubes(cube);
                        _explosion.Explode(_spawner.GetRigidbodys());
                    }
                }

                Destroy(cube.gameObject);
            }
        }
    }

    private bool CheckPossibilitySeparation(Cube cube)
    {
        bool isSeparationPossible = false;
        float minimumNumber = 0;
        float maximumNumber = 100;

        float randomNumber = Random.Range(minimumNumber, maximumNumber + 1);

        if (randomNumber <= cube.ChanceSeparation)
        {
            isSeparationPossible = true;
        }

        return isSeparationPossible;
    }
}
