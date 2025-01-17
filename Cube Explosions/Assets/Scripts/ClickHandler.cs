using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

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

            if (Physics.Raycast(ray, out RaycastHit hit, _rayLength, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.GetSplitPossibility())
                    {
                        _explosion.Explode(_spawner.CreateCubes(cube));
                    }
                    else
                    {
                        _explosion.Explode(cube);
                    }
                }

                Destroy(cube.gameObject);
            }
        }
    }
}
