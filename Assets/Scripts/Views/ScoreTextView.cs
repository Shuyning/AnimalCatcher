using AnimalCatcher.Controllers;
using TMPro;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Views
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreTextView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;

        private IScoreCounter _scoreCounter;

        [Inject]
        private void Construct(IScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            UpdateText(_scoreCounter.CurrentScore);
            _scoreCounter.ScoreUpdated += UpdateText;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreUpdated -= UpdateText;
        }

        private void UpdateText(int amount)
        {
            _scoreText.text = amount.ToString();
        }
    }   
}