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

namespace AnimalCatcher.Controllers
{
    public class AnimalSpawnController : IDisposable, IAnimalSpawner
    {
        private readonly AnimalSpawnConfig _animalSpawnConfig;
        private readonly AnimalPool.Pool _animalPool;
        private readonly Transform _poolTransform;

        private readonly List<AnimalPool> _spawnAnimals;
        private bool _isStart;

        private CancellationTokenSource _cancellationToken;

        [Inject]
        private AnimalSpawnController(AnimalSpawnConfig animalSpawnConfig, AnimalPool.Pool animalPool, Transform transform)
        {
            _animalSpawnConfig = animalSpawnConfig;
            _animalPool = animalPool;
            _poolTransform = transform;

            _spawnAnimals = new List<AnimalPool>();
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

        public void Despawn(AnimalPool animalPool)
        {
            if (_spawnAnimals.Contains(animalPool))
                _spawnAnimals.Remove(animalPool);
            
            _animalPool.Despawn(animalPool);
            TrySpawnAnimal();
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
            _spawnAnimals.Add(_animalPool.Spawn(_poolTransform, Vector3.zero));
            TrySpawnAnimal();
        }
    }
}