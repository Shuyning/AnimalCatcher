using AnimalCatcher.Controllers;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class AnimalComponentStorage : MonoBehaviour, IAnimalComponentGetter
    {
        [SerializeField] private AnimalMoveBehaviour animalMoveBehaviour;
        [SerializeField] private Transform animalTransform;
        [SerializeField] private AnimalPool animalPool;
        
        public ICharacterFollowerStorage CharacterFollowerStorage { get; private set; }
        public IEndYardPositionGetter EndYardPositionGetter { get; private set; }
        public IPatrolGetter PatrolGetter { get; private set; }
        public IAnimalMoveBehaviour AnimalMoveBehaviour => animalMoveBehaviour;
        public IAnimalObserver AnimalObserver => animalPool;
        public Vector3 AnimalPosition => animalTransform.position;

        [Inject]
        private void Construct(IPatrolGetter patrolGetter, ICharacterFollowerStorage characterFollowerStorage,
            IEndYardPositionGetter yardPositionGetter)
        {
            PatrolGetter = patrolGetter;
            EndYardPositionGetter = yardPositionGetter;
            CharacterFollowerStorage = characterFollowerStorage;
        }
    }
}