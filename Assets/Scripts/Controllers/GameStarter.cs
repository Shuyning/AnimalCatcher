using UnityEngine;
using Zenject;

namespace AnimalCatcher.Controllers
{
    public class GameStarter : MonoBehaviour
    {
        private IAnimalSpawner _animalSpawner;
        private CharacterSpawner _characterSpawner;

        [Inject]
        private void Construct(CharacterSpawner characterSpawner, IAnimalSpawner animalSpawner)
        {
            _characterSpawner = characterSpawner;
            _animalSpawner = animalSpawner;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _characterSpawner.CharacterSpawn();
            _animalSpawner.StartSpawn();
        }
    }
}