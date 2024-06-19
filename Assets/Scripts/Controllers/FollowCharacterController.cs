using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCatcher.Components;
using AnimalCatcher.Components.Enums;
using AnimalCatcher.Models;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Controllers
{
    public class FollowCharacterController : ITickable, IDisposable, IFollowCharacterSetter, ICharacterFollowerStorage
    {
        private readonly FollowCharacterConfig _followCharacterConfig;

        private readonly List<IAnimalStateMachine> _followers;

        private Transform _characterTransform;

        [Inject]
        private FollowCharacterController(FollowCharacterConfig followCharacterConfig)
        {
            _followCharacterConfig = followCharacterConfig;
            _followers = new List<IAnimalStateMachine>();
        }

        public void Tick()
        {
            SetFollowTargets();
        }
        
        public void Dispose()
        {
            foreach (var follower in _followers)
                follower.AnimalDespawned -= RemoveFollow;
            
            _followers.Clear();
        }

        public void SetCharacterTransform(Transform transform)
        {
            _characterTransform = transform;
        }

        public void AddFollower(IAnimalStateMachine animalStateMachine)
        {
            if (_followers.Count >= _followCharacterConfig.MaxFollowTarget 
                || _followers.Contains(animalStateMachine))
                return;
            
            _followers.Add(animalStateMachine);
            animalStateMachine.SwitchState(AnimalStateType.Follow);
        }

        public void RemoveFollow(IAnimalStateMachine animalStateMachine)
        {
            if (_followers.Contains(animalStateMachine))
                _followers.Remove(animalStateMachine);
        }

        private void SetFollowTargets()
        {
            if (!_followers.Any())
                return;

            _followers[0].AnimalComponentGetter.AnimalMoveBehaviour.SetFollowTarget(_characterTransform.position);
            
            if (_followers.Count == 1)
                return;
            
            for (int i = 1; i < _followers.Count; i++)
                _followers[i].AnimalComponentGetter.AnimalMoveBehaviour.SetFollowTarget(_followers[i - 1].AnimalComponentGetter.AnimalPosition);
        }
    }
}