using UnityEngine;


namespace StatsenkoAA
{
    public sealed class ManageUnitPath : MonoBehaviour
    {
        [SerializeField] private GameObject _pointToMove;

        [SerializeField] private Camera _mainCamera;
        private Transform _hitRayPoint;
        private int _rightMouseButton = 1;

        //private void Start()
        //{
        //    _mainCamera = Camera.main;
        //}

        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                Transform _hitRayPoint = hit.transform;
            }

            if (Input.GetMouseButtonDown(_rightMouseButton))
            {
                Instantiate(_pointToMove, _hitRayPoint);
            }
        }
    }
}
