using UnityEngine;

namespace AnimalCatcher.Components
{
    public class AnimalPatrolState : AnimalState
    {
        private const float DistanceOffset = 0.05f;
        
        private int _currentTargetIndex;
        private Vector2[] _targets;

        private IAnimalMoveBehaviour _animalMoveBehaviour;

        public override void OnEnter(IAnimalStateMachine animalStateMachine)
        {
            _currentTargetIndex = 0;
            _targets = animalStateMachine.AnimalComponentGetter.PatrolGetter.GetRandomPositionsArray();
            _animalMoveBehaviour = animalStateMachine.AnimalComponentGetter.AnimalMoveBehaviour;
            _animalMoveBehaviour.MoveToPosition(_targets[_currentTargetIndex]);
            _animalMoveBehaviour.SetFollowTarget(_targets[_currentTargetIndex]);
        }

        public override void OnUpdate(IAnimalStateMachine animalStateMachine)
        {
            TryUpdateTarget(animalStateMachine.AnimalComponentGetter.AnimalPosition);
            _animalMoveBehaviour.SetFollowTarget(_targets[_currentTargetIndex]);
        }

        public override void OnExit(IAnimalStateMachine animalStateMachine)
        {
            _targets = null;
        }

        private void TryUpdateTarget(Vector3 position)
        {
            float distance = Vector3.Distance(position, _targets[_currentTargetIndex]);
            
            if (distance <= _animalMoveBehaviour.StopDistance + DistanceOffset)
                UpIndex();
        }

        private void UpIndex()
        {
            ++_currentTargetIndex;

            if (_currentTargetIndex >= _targets.Length)
                _currentTargetIndex = 0;
        }
    }
}