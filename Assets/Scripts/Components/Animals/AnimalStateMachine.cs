using System;
using AnimalCatcher.Components.Enums;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class AnimalStateMachine : MonoBehaviour, IAnimalStateMachine
    {
        public class Pool : MonoMemoryPool<Transform, Vector3, AnimalStateMachine>
        {
            protected override void Reinitialize(Transform parent, Vector3 position, AnimalStateMachine item)
            {
                base.Reinitialize(parent, position, item);
                item.transform.SetParent(parent);
                item.transform.position = position;
                item.transform.rotation = Quaternion.identity;
                item.gameObject.SetActive(true);
            }

            protected override void OnDespawned(AnimalStateMachine item)
            {
                base.OnDespawned(item);
                item.SwitchState(AnimalStateType.Idle);
                item.AnimalDespawned?.Invoke(item);
                item.gameObject.SetActive(false);
            }
        }

        [SerializeField] private AnimalComponentStorage animalComponentStorage;

        private readonly AnimalStateStorage _animalStateStorage = new AnimalStateStorage();
        private AnimalState _currentState;
        private AnimalStateType _currentAnimalStateType = AnimalStateType.Idle;

        public IAnimalComponentGetter AnimalComponentGetter => animalComponentStorage;
        
        public event Action<IAnimalStateMachine> AnimalDespawned;

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