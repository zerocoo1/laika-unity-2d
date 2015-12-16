using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Laika
{
    public class BonusController : MonoBehaviour
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public GameObject BonusPrefab;

        /// <summary>
        /// Private params:
        /// </summary>

        private List<Bonus> _bonusesList;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void SpawnBonus()
        {
            Vector3 randomPoint = new Vector3(Random.Range(-4, 4), Random.Range(-2, 2), 0f);

            Bonus bonus = _bonusesList.Find(b => b.IsSpawned = false);

            if (bonus == null)
            {
                SpawnNewBonus(randomPoint);
            }
            else
            {
                bonus.Spawn(randomPoint);
            }
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Start()
        {
            _bonusesList = new List<Bonus>();
        }

        private void SpawnNewBonus(Vector3 spawnPoint)
        {
            GameObject bonusObj = Instantiate(BonusPrefab, spawnPoint, Quaternion.identity) as GameObject;

            if (bonusObj == null) return;

            bonusObj.transform.SetParent(transform);

            Bonus bonus = bonusObj.GetComponent<Bonus>();

            bonus.Spawn(spawnPoint);

            _bonusesList.Add(bonus);
        }
    }
}