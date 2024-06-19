using AnimalCatcher.Controllers;
using Controllers.Interfaces;
using UnityEngine;

namespace AnimalCatcher.Components
{
    public interface IAnimalComponentGetter
    {
        public ICharacterFollowerStorage CharacterFollowerStorage { get; }
        public IAnimalMoveBehaviour AnimalMoveBehaviour { get; }
        public IPatrolGetter PatrolGetter { get; }
        public Vector3 AnimalPosition { get; }
    }
}