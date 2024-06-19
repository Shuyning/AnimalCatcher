using UnityEngine;

namespace Components.Interfaces
{
    public interface IScreenPointConverter
    {
        public Vector3 GetWorldPositionFromScreenTouch(Vector2 mousePosition);
    }
}