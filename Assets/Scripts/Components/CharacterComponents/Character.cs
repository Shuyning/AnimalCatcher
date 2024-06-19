using System;
using AnimalCatcher.Components.Enums;
using Controllers.Interfaces;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace AnimalCatcher.Components
{
    public class Character : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Object, Character> { }

        private ICharacterFollowerStorage _characterFollowerStorage;

        [Inject]
        private void Construct(ICharacterFollowerStorage characterFollowerStorage)
        {
            _characterFollowerStorage = characterFollowerStorage;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IAnimalStateMachine animalStateMachine))
            {
                _characterFollowerStorage.AddFollower(animalStateMachine);
                return;
            }
        }
    }   
}