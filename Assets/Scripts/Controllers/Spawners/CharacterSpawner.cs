using AnimalCatcher.Components;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Controllers
{
    public class CharacterSpawner
    {
        private readonly Character.Factory _characterFactory;
        private readonly Character _characterPrefab;

        private readonly IFollowCharacterSetter _followCharacterSetter;

        private Character _currentCharacter;

        [Inject]
        private CharacterSpawner(Character.Factory factory, Character character,
            IFollowCharacterSetter followCharacterSetter)
        {
            _characterFactory = factory;
            _characterPrefab = character;
            _followCharacterSetter = followCharacterSetter;
        }

        public void CharacterSpawn()
        {
            Despawn();
            _currentCharacter = _characterFactory.Create(_characterPrefab);
            _currentCharacter.transform.position = Vector3.zero;
            _followCharacterSetter.SetCharacterTransform(_currentCharacter.transform);
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