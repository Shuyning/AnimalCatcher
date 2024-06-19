using System;

namespace Controllers.Interfaces
{
    public interface IScoreCounter
    {
        public int CurrentScore { get; }

        public event Action<int> ScoreUpdated;

        public void Increase();
    }
}