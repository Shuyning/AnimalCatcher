using AnimalCatcher.Controllers;
using Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class AnimalComponentStorage : MonoBehaviour, IAnimalComponentGetter
    {
        [SerializeField] private AnimalMoveBehaviour animalMoveBehaviour;
        [SerializeField] private Transform animalTransform;

        public ICharacterFollowerStorage CharacterFollowerStorage { get; private set; }
        public IPatrolGetter PatrolGetter { get; private set; }
        public IAnimalMoveBehaviour AnimalMoveBehaviour => animalMoveBehaviour;
        public Vector3 AnimalPosition => animalTransform.position;

        [Inject]
        private void Construct(IPatrolGetter patrolGetter, ICharacterFollowerStorage characterFollowerStorage)
        {
            PatrolGetter = patrolGetter;
            CharacterFollowerStorage = characterFollowerStorage;
        }
    }
}