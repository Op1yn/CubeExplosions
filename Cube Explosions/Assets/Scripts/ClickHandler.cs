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
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.CheckPossibilitySeparation())
                    {
                        _explosion.Explode(_spawner.CreateCubes(cube));
                    }
                }

                Destroy(cube.gameObject);
            }
        }
    }
}
