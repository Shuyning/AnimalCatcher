using AnimalCatcher.Components.Enums;

namespace AnimalCatcher.Components
{
    public interface IAnimalStateMachine
    {
        public IAnimalComponentGetter AnimalComponentGetter { get; }
        public AnimalStateType AnimalStateType { get; }
        
        public void SwitchState(AnimalStateType animalState);
    }
}