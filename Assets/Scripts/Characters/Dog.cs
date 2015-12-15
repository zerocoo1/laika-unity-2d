using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Dog : Character
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public LayerMask DowVisionLayerMask;

        /// <summary>
        /// Private params:
        /// </summary>

        private float _takeControllRadius = 1.2f;
        private float _visionInterval = .5f;

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

            MoveSpeed = 2.5f;
            StartCoroutine(CheckVision());
        }
    }
}
