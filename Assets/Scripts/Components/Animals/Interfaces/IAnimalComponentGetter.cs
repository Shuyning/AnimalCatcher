using AnimalCatcher.Controllers;
using UnityEngine;

namespace AnimalCatcher.Components
{
    public interface IAnimalComponentGetter
    {
        public IAnimalObserver AnimalObserver { get; }
        public ICharacterFollowerStorage CharacterFollowerStorage { get; }
        public IEndYardPositionGetter EndYardPositionGetter { get; }
        public IAnimalMoveBehaviour AnimalMoveBehaviour { get; }
        public IPatrolGetter PatrolGetter { get; }
        public Vector3 AnimalPosition { get; }
    }
}