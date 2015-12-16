using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Dog : Character
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public int DogId;
        public LayerMask DowVisionLayerMask;
        

        public void DogReceiveCommands(bool isReceive)
        {
            TargetPoint = transform.position;
            _isReceiveCommands = isReceive;
        } 

        /// <summary>
        /// Private params:
        /// </summary>

        private float _takeControllRadius = .6f;
        private float _visionInterval = .5f;
        private bool _isReceiveCommands = false;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Vision()
        {
            VisionHelper.Vision2D(_takeControllRadius, transform, DowVisionLayerMask, targetTransform =>
            {
                IFollow canFollow = targetTransform.GetComponent<IFollow>();
                if (canFollow != null) canFollow.FollowMe();
            }, null);
        }

        private IEnumerator CheckVision()
        {
            while (true)
            {
                Vision();
                yield return new WaitForSeconds(_visionInterval);
            }
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected override void OnAwake()
        {
            base.OnAwake();

            MoveSpeed = 2.2f;
            StartCoroutine(CheckVision());
        }

        protected override void OnFixedUpdate()
        {
            if (_isReceiveCommands) Move();
        }
    }
}
