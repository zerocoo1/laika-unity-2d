using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Laika
{
    public class CowController : MonoBehaviour
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public Transform[] WayPoints;
        public GameObject CowPrefab;
        public Transform CowParenTransform; 

        /// <summary>
        /// Private params:
        /// </summary>

        private List<Cow> _cowsPool;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Start()
        {
            _cowsPool = new List<Cow>();

            InsertFirstCows();

            StartCoroutine(RespanwCows());
        }

        private void InitNewCow(Transform poinTransform)
        {
            GameObject cowObj = Instantiate(CowPrefab, poinTransform.position, Quaternion.identity) as GameObject;

            if (cowObj == null) return;

            cowObj.transform.SetParent(CowParenTransform);

            Cow cow = cowObj.GetComponent<Cow>();

            _cowsPool.Add(cow);
        }

        private void InsertFirstCows()
        {
            for (int i = 1; i < WayPoints.Length; i++)
            {
                InitNewCow(WayPoints[i]);
            }
        }

        private IEnumerator RespanwCows()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);

                Cow despawnCow = _cowsPool.Find(c => c.CurCowState == Cow.CowState.Inactive);

                if (despawnCow != null)
                {
                    despawnCow.SpawnAndGo(WayPoints[0].position, WayPoints[Random.Range(1, WayPoints.Length - 1)].position);
                }
            }
        }
    }
}
