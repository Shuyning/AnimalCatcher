using System;
using System.Collections.Generic;
using System.Threading;
using AnimalCatcher.Components;
using AnimalCatcher.Components.Enums;
using AnimalCatcher.Models;
using AnimalCatcher.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Controllers.Spawners
{
    public class AnimalSpawnController : IDisposable, IAnimalSpawner
    {
        private readonly AnimalSpawnConfig _animalSpawnConfig;
        private readonly AnimalStateMachine.Pool _animalPool;
        private readonly Transform _poolTransform;

        private readonly List<AnimalStateMachine> _spawnAnimals;
        private bool _isStart;

        private CancellationTokenSource _cancellationToken;

        [Inject]
        private AnimalSpawnController(AnimalSpawnConfig animalSpawnConfig, AnimalStateMachine.Pool animalPool, Transform transform)
        {
            _animalSpawnConfig = animalSpawnConfig;
            _animalPool = animalPool;
            _poolTransform = transform;

            _spawnAnimals = new List<AnimalStateMachine>();
            _isStart = false;
        }
        
        public void Dispose()
        {
            _spawnAnimals.Clear();
            _animalPool?.Clear();
            
            _cancellationToken.CancelAndDispose();
        }

        public void StartSpawn()
        {
            if (_isStart)
                return;

            _isStart = true;
            TrySpawnAnimal();
        }

        public void Despawn(AnimalStateMachine animalStateMachine)
        {
            if (_spawnAnimals.Contains(animalStateMachine))
                _spawnAnimals.Remove(animalStateMachine);
            
            _animalPool.Despawn(animalStateMachine);
        }

        private void TrySpawnAnimal()
        {
            if (_spawnAnimals.Count >= _animalSpawnConfig.MaxActiveAnimalAmount)
                return;

            StartSpawnTimer().Forget();
        }

        private async UniTaskVoid StartSpawnTimer()
        {
            if (_spawnAnimals.Count == 0)
            {
                Spawn();
                return;
            }
            
            _cancellationToken?.CancelAndDispose();
            _cancellationToken = new CancellationTokenSource();
            
            float time = UnityRandom.GetRandomFloat(_animalSpawnConfig.MinSpawnTime, _animalSpawnConfig.MaxSpawnTime);

            try
            {
                await UniTask.WaitForSeconds(time, false, PlayerLoopTiming.Update, _cancellationToken.Token);
                Spawn();
            }
            catch (Exception e) { }
        }

        private void Spawn()
        {
            AnimalStateMachine animalStateMachine = _animalPool.Spawn(_poolTransform, Vector3.zero);
            animalStateMachine.SwitchState(AnimalStateType.Patrol);
            
            _spawnAnimals.Add(animalStateMachine);
            TrySpawnAnimal();
        }
    }
}