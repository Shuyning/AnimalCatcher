using Controllers.Spawners;
using Zenject;

namespace Controllers
{
    public class GameStarter : IInitializable
    {
        private readonly CharacterSpawner _characterSpawner;

        [Inject]
        private GameStarter(CharacterSpawner characterSpawner)
        {
            _characterSpawner = characterSpawner;
        }
        
        public void Initialize()
        {
            StartGame();
        }

        private void StartGame()
        {
            _characterSpawner.CharacterSpawn();
        }
    }
}