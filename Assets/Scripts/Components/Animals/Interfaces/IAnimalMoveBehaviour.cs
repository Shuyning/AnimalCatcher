using UnityEngine;

namespace AnimalCatcher.Components
{
    public interface IAnimalMoveBehaviour
    {
        public float StopDistance { get; }
        
        public void SetFollowTarget(Vector3 position);
        public void MoveToPosition(Vector3 position);
    }
}