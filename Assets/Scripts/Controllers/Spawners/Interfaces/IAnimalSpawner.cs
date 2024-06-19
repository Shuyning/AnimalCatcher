using AnimalCatcher.Components;

namespace AnimalCatcher.Controllers
{
    public interface IAnimalSpawner
    {
        public void StartSpawn();
        public void Despawn(AnimalPool animalPool);
    }
}