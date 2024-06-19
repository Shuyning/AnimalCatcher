using AnimalCatcher.Components.Enums;
using AnimalCatcher.Controllers;
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
                TryFollow(animalStateMachine);
        }

        private void TryFollow(IAnimalStateMachine animalStateMachine)
        {
            if (animalStateMachine.AnimalStateType != AnimalStateType.Patrol)
                return;
                
            _characterFollowerStorage.AddFollower(animalStateMachine);
        }
    }   
}