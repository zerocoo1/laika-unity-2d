using UnityEngine;
using System.Collections;

namespace Laika
{
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public int GameScore { get { return _gameScore; } private set { _gameScore = value; } }
        public int GameBonus { get { return _gameBonus; } private set { _gameBonus = value; } }

        /// <summary>
        /// Private params:
        /// </summary>

        [SerializeField]
        private int _gameScore = 0;
        [SerializeField]
        private int _gameBonus = 0;
        private int _bonusCounter = 0;
        private UIController _uiController;
        private BonusController _bonusController;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void IncreasScore()
        {
            _gameScore++;
            _bonusCounter++;

            if (_bonusCounter == 5)
            {
                SpawnBonus();
                _bonusCounter = 0;
            }

            _uiController.UpdateScore();
        }

        public void IncreasBonus()
        {
            _gameBonus++;
            _uiController.UpdateScore();
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Awake()
        {
            _uiController = FindObjectOfType<UIController>();
            _bonusController = FindObjectOfType<BonusController>();
        }

        private void SpawnBonus()
        {
            _bonusController.SpawnBonus();
        }
    }
}
