using AnimalCatcher.Components.Enums;

namespace AnimalCatcher.Components
{
    public interface IAnimalStateMachine : IAnimalObserver
    {
        public IAnimalComponentGetter AnimalComponentGetter { get; }
        
        public void SwitchState(AnimalStateType animalState);
    }
}