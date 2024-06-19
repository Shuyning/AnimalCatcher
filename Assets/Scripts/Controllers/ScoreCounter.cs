﻿using System;

namespace AnimalCatcher.Controllers
{
    public class ScoreCounter : IScoreCounter
    {
        public int CurrentScore { get; private set; } = 0;

        public event Action<int> ScoreUpdated;

        public void Increase()
        {
            ++CurrentScore;
            ScoreUpdated?.Invoke(CurrentScore);
        }
    }
}