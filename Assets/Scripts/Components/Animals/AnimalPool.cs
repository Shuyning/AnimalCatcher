using System;
using AnimalCatcher.Components.Enums;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class AnimalPool : MonoBehaviour, IAnimalObserver
    {
        public class Pool : MonoMemoryPool<Transform, Vector3, AnimalPool>
        {
            protected override void Reinitialize(Transform parent, Vector3 position, AnimalPool item)
            {
                base.Reinitialize(parent, position, item);
                item.transform.SetParent(parent);
                item.transform.position = position;
                item.transform.rotation = Quaternion.identity;
                item.gameObject.SetActive(true);
                item.animalStateMachine.SwitchState(AnimalStateType.Patrol);
            }

            protected override void OnDespawned(AnimalPool item)
            {
                base.OnDespawned(item);
                item.animalStateMachine.SwitchState(AnimalStateType.Idle);
                item.AnimalDespawned?.Invoke(item.animalStateMachine);
                item.gameObject.SetActive(false);
            }
        }

        [SerializeField] private AnimalStateMachine animalStateMachine;

        public event Action<IAnimalStateMachine> AnimalDespawned;
    }
}