using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Cow : Character, IChill, IFollow
    {
        /// <summary>
        /// Private params:
        /// </summary>

        private enum CowState
        {
            Inactive,
            FreeMove,
            Follow,
            Chill
        }

        private CowState _curCowState = CowState.FreeMove;
        private float _followCountdown = 3.2f;
        private float _waitToChill = 1.3f;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void FollowMe()
        {
            if (_curCowState != CowState.FreeMove) return;

            ChangeCowState(CowState.Follow);
        }

        public void TakeChill()
        {
            StartCoroutine(WaitToChill());
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void ChangeCowState(CowState state)
        {
            if (_curCowState == state) return;

            _curCowState = state;

            switch (state)
            {
                case CowState.Chill:
                    StopAllCoroutines();
                    break;

                default:
                    break;
            }
        }

        private IEnumerator FollowCountdown()
        {
            while (true)
            {
                yield return new WaitForSeconds(_followCountdown);

                if (_curCowState == CowState.Follow) ChangeCowState(CowState.FreeMove);
            }
        }

        private IEnumerator WaitToChill()
        {
            yield return new WaitForSeconds(_waitToChill);

            ChangeCowState(CowState.Chill);
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected override void OnAwake()
        {
            base.OnAwake();

            StartCoroutine(FollowCountdown());
        }

        protected override void OnFixedUpdate()
        {
            if (_curCowState != CowState.Follow) return;
            
            Move();
        }
    }
}
