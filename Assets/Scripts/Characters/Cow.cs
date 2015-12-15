using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Cow : Character
    {
        /// <summary>
        /// Private params:
        /// </summary>

        private enum CowState
        {
            Inactive,
            FreeMove,
            Follow
        }

        private CowState _curCowState = CowState.Inactive;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void FolowDog()
        {
            ChangeCowState(CowState.Follow);
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void ChangeCowState(CowState state)
        {
            _curCowState = state;

            switch (state)
            {
                case CowState.Follow:
                    break;

                case CowState.FreeMove:
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected override void OnFixedUpdate()
        {
            if (_curCowState != CowState.Follow) return;
            
            Move();
        }
    }
}
