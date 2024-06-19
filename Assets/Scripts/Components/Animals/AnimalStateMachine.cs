using System;
using AnimalCatcher.Components.Enums;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class AnimalStateMachine : MonoBehaviour, IAnimalStateMachine
    {
        [SerializeField] private AnimalComponentStorage animalComponentStorage;

        private readonly AnimalStateStorage _animalStateStorage = new AnimalStateStorage();
        private AnimalState _currentState;
        private AnimalStateType _currentAnimalStateType = AnimalStateType.Idle;

        public IAnimalComponentGetter AnimalComponentGetter => animalComponentStorage;
        public AnimalStateType AnimalStateType => _currentAnimalStateType;

        private void Update()
        {
            _currentState?.OnUpdate(this);
        }

        private void OnDestroy()
        {
            _currentState?.OnExit(this);
            _currentState = null;
            _animalStateStorage.Dispose();
        }

        public void SwitchState(AnimalStateType animalState)
        {
            if (_currentAnimalStateType == animalState)
                return;
            
            _currentState?.OnExit(this);

            if (!_animalStateStorage.AnimalStates.TryGetValue(animalState, out _currentState))
                return;
            
            _currentAnimalStateType = animalState;
            _currentState.OnEnter(this);
        }
    }   
}