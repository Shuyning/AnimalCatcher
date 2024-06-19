using AnimalCatcher.Components;

namespace AnimalCatcher.Controllers
{
    public interface ICharacterFollowerStorage
    {
        public void AddFollower(IAnimalStateMachine animalStateMachine);
        public void RemoveFollow(IAnimalStateMachine animalStateMachine);
    }
}