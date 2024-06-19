using System;
using System.Collections.Generic;
using AnimalCatcher.Components.Enums;

namespace AnimalCatcher.Components
{
    public class AnimalStateStorage : IDisposable
    {
        private Dictionary<AnimalStateType, AnimalState> _animalStates;

        public IDictionary<AnimalStateType, AnimalState> AnimalStates => _animalStates;

        public AnimalStateStorage()
        {
            _animalStates = new Dictionary<AnimalStateType, AnimalState>();
            
            _animalStates.Add(AnimalStateType.Idle, new IdleAnimalState());
            _animalStates.Add(AnimalStateType.Follow, new FollowAnimalState());
            _animalStates.Add(AnimalStateType.Patrol, new AnimalPatrolState());
            _animalStates.Add(AnimalStateType.Yard, new YardAnimalState());
        }

        public void Dispose()
        {
            _animalStates.Clear();
        }
    }
}