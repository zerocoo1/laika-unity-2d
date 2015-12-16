using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Laika
{
    public class UIController : MonoBehaviour
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public Text ScoreText;
        public Text BonusText;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void UpdateScore()
        {
            ScoreText.text = string.Format("Score: {0}", GameManager.Instance.GameScore);
            BonusText.text = string.Format("Bonus: {0}", GameManager.Instance.GameScore);
        }
    }
}
