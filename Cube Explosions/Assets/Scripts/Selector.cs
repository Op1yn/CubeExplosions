using System;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Camera _mainCamera;
    private float _rayLength = 100;
    private int _leftMouseButton = 0;

    public event Action<Cube> SelectedCube;

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
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    SelectedCube?.Invoke(cube);

                }

                Destroy(cube.gameObject);
            }
        }
    }
}
