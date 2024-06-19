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
        private ICameraValueConverter _cameraValueConverter;
        
        private NavMeshAgent _navMeshAgent;

        [Inject]
        private void Construct(IScreenInputObserver screenInputObserver, ICameraValueConverter cameraValueConverter)
        {
            _screenInputObserver = screenInputObserver;
            _cameraValueConverter = cameraValueConverter;
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
            _screenInputObserver.SingleTouchInputHandled += UpdateCharacterPosition;
        }

        private void OnDisable()
        {
            _screenInputObserver.SingleTouchInputHandled -= UpdateCharacterPosition;
        }

        private void UpdateCharacterPosition(Vector2 vector2)
        {
            _navMeshAgent.SetDestination(_cameraValueConverter.GetWorldPositionFromMouseTouch(vector2));
        }
    }
}