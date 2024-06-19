using UnityEngine;

namespace Components.Interfaces
{
    public interface ICameraValueConverter
    {
        public Vector3 GetWorldPositionFromMouseTouch(Vector2 mousePosition);
    }
}