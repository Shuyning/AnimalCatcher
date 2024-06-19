using AnimalCatcher.Components;
using UnityEngine;
using Zenject;

namespace Controllers.Spawners
{
    public class CharacterSpawner
    {
        private readonly Character.Factory _characterFactory;
        private readonly Character _characterPrefab;

        private Character _currentCharacter;

        [Inject]
        private CharacterSpawner(Character.Factory factory, Character character)
        {
            _characterFactory = factory;
            _characterPrefab = character;
        }

        public void CharacterSpawn()
        {
            Despawn();
            _currentCharacter = _characterFactory.Create(_characterPrefab);
            _currentCharacter.transform.position = Vector3.zero;
        }

        public void Despawn()
        {
            if (_currentCharacter == null)
                return;
            
            Object.Destroy(_currentCharacter);
            _currentCharacter = null;
        }
    }
}