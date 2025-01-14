using System;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private Camera _mainCamera;
    private float _rayLength = 100;

    public event Action<Cube> SelectedCube;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    SelectedCube?.Invoke(cube);
                }
            }
        }
    }
}
