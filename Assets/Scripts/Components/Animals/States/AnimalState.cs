namespace AnimalCatcher.Components
{
    public abstract class AnimalState
    {
        public abstract void OnEnter(IAnimalStateMachine animalStateMachine);
        public abstract void OnUpdate(IAnimalStateMachine animalStateMachine);
        public abstract void OnExit(IAnimalStateMachine animalStateMachine);
    }   
}