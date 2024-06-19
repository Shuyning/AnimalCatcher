﻿using AnimalCatcher.Controllers;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Components
{
    public class YardGate : MonoBehaviour
    {
        private IAnimalSpawner _animalSpawner;
        private IScoreCounter _scoreCounter;

        [Inject]
        private void Construct(IAnimalSpawner animalSpawner, IScoreCounter scoreCounter)
        {
            _animalSpawner = animalSpawner;
            _scoreCounter = scoreCounter;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out AnimalPool animalPool))
            {
                _animalSpawner.Despawn(animalPool);
                _scoreCounter.Increase();
                return;
            }
        }
    }
}