namespace AnimalCatcher.Components
{
    public class YardAnimalState : AnimalState
    {
        public override void OnEnter(IAnimalStateMachine animalStateMachine)
        {
            animalStateMachine.AnimalComponentGetter.AnimalMoveBehaviour.
                SetFollowTarget(animalStateMachine.AnimalComponentGetter.EndYardPositionGetter.EndYardPosition);
        }
        
        public override void OnUpdate(IAnimalStateMachine animalStateMachine) { }
        public override void OnExit(IAnimalStateMachine animalStateMachine) { }
    }
}