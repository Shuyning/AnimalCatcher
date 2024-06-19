using UnityEngine;
using UnityEngine.AI;

namespace AnimalCatcher.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimalMoveBehaviour : MonoBehaviour, IAnimalMoveBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        public float StopDistance => _navMeshAgent.stoppingDistance;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        public void SetFollowTarget(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
        }

        public void MoveToPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}