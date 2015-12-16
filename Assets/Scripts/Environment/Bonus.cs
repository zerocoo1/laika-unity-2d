using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Bonus : MonoBehaviour
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public bool IsSpawned = false;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void Spawn(Vector3 spawnPoint)
        {
            IsSpawned = true;
            transform.position = spawnPoint;

            StartCoroutine(WaitToDespawn());
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void OnTriggerEnter2D(Collider2D other)
        {
            Dog dog = other.transform.GetComponent<Dog>();

            if (dog != null && IsSpawned)
            {
                GameManager.Instance.IncreasBonus();
                Despawn();
            }
        }

        private void Despawn()
        {
            StopAllCoroutines();
            transform.position = new Vector3(0f, 0f, 10f);
            IsSpawned = false;
        }

        private IEnumerator WaitToDespawn()
        {
            yield return new WaitForSeconds(10f);
            Despawn();
        }
    }
}
