using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Laika
{
    public class UIController : MonoBehaviour
    {
        public Text ScoreText;
        public Text BonusText;

        public void UpdateScore()
        {
            ScoreText.text = string.Format("Score: {0}", GameManager.Instance.GameScore);
            ScoreText.text = string.Format("Bonus: {0}", GameManager.Instance.GameScore);
        }
    }
}
