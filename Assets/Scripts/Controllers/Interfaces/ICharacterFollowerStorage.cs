using AnimalCatcher.Components;

namespace Controllers.Interfaces
{
    public interface ICharacterFollowerStorage
    {
        public void AddFollower(IAnimalStateMachine animalStateMachine);
        public void RemoveFollow(IAnimalStateMachine animalStateMachine);
    }
}