using System;
using AnimalCatcher.Controllers;
using Components.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace AnimalCatcher.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterMoveBehaviour : MonoBehaviour
    {
        private IScreenInputObserver _screenInputObserver;
        private IScreenPointConverter _screenPointConverter;
        
        private NavMeshAgent _navMeshAgent;

        [Inject]
        private void Construct(IScreenInputObserver screenInputObserver, IScreenPointConverter screenPointConverter)
        {
            _screenInputObserver = screenInputObserver;
            _screenPointConverter = screenPointConverter;
        }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;

            _navMeshAgent.SetDestination(Vector3.zero);
        }

        private void OnEnable()
        {
            _screenInputObserver.SingleTouchInputHandled += MoveToPosition;
        }

        private void OnDisable()
        {
            _screenInputObserver.SingleTouchInputHandled -= MoveToPosition;
        }

        private void MoveToPosition(Vector2 vector2)
        {
            _navMeshAgent.SetDestination(_screenPointConverter.GetWorldPositionFromScreenTouch(vector2));
        }
    }
}