using AnimalCatcher.Components;

namespace Controllers.Spawners
{
    public interface IAnimalSpawner
    {
        public void StartSpawn();
        public void Despawn(AnimalStateMachine animalStateMachine);
    }
}