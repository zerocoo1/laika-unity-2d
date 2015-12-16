using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Cow : Character, IChill, IFollow
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public enum CowState
        {
            Inactive,
            FreeMove,
            Follow,
            Chill
        }

        public CowState CurCowState = CowState.FreeMove;

        /// <summary>
        /// Private params:
        /// </summary>

        private float _followCountdown = 3.2f;
        private float _waitToChill = 1.3f;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void FollowMe()
        {
            if (CurCowState != CowState.FreeMove) return;

            ChangeCowState(CowState.Follow);
        }

        public void TakeChill()
        {
            StartCoroutine(WaitToChill());
        }

        public void SpawnAndGo(Vector2 spawnPoint, Vector2 wayPoint)
        {
            transform.position = spawnPoint;
            ChangeCowState(CowState.FreeMove);
            TargetPoint = wayPoint;
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void ChangeCowState(CowState state)
        {
            if (CurCowState == state) return;

            CurCowState = state;

            switch (state)
            {
                case CowState.Chill:
                    StartCoroutine(WaitToDespawn());
                    break;

                case CowState.Inactive:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
                    StopAllCoroutines();
                    break;

                default:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                    break;
            }
        }

        private IEnumerator FollowCountdown()
        {
            while (true)
            {
                yield return new WaitForSeconds(_followCountdown);

                if (CurCowState == CowState.Follow) ChangeCowState(CowState.FreeMove);
            }
        }

        private IEnumerator WaitToChill()
        {
            yield return new WaitForSeconds(_waitToChill);

            ChangeCowState(CowState.Chill);
        }

        private IEnumerator WaitToDespawn()
        {
            yield return new WaitForSeconds(_waitToChill);

            ChangeCowState(CowState.Inactive);
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected override void OnAwake()
        {
            base.OnAwake();

            StartCoroutine(FollowCountdown());
        }

        protected override void OnSetDestination(Vector2 point)
        {
            if (CurCowState == CowState.Follow) TargetPoint = point;
        }
    }
}
