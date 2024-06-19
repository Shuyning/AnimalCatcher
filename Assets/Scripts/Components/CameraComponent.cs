using Components.Interfaces;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraComponent : MonoBehaviour, IScreenPointConverter
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        public Vector3 GetWorldPositionFromScreenTouch(Vector2 mousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 touchPos = ray.GetPoint(distance);
                touchPos.z = 0;
                return touchPos;
            }

            return Vector3.zero;
        }
    }
}