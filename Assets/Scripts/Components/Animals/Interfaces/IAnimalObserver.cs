using System;

namespace AnimalCatcher.Components
{
    public interface IAnimalObserver
    {
        public event Action<IAnimalStateMachine> AnimalDespawned;
    }
}