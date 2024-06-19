using Controllers.Spawners;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameStarter : MonoBehaviour
    {
        private CharacterSpawner _characterSpawner;

        [Inject]
        private void Construct(CharacterSpawner characterSpawner)
        {
            _characterSpawner = characterSpawner;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _characterSpawner.CharacterSpawn();
        }
    }
}