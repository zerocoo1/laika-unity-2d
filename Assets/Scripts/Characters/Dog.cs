using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Dog : Character
    {
        public LayerMask DowVisionLayerMask;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Vision()
        {
            VisionHelper.Vision2D(.8f, transform, DowVisionLayerMask, targetTransform =>
            {
                IFollow canFollow = targetTransform.GetComponent<IFollow>();
                if (canFollow != null) canFollow.FollowMe();
            },
            () =>
            {
                
            });
        }

        private IEnumerator CheckVision()
        {
            while (true)
            {
                Vision();
                yield return new WaitForSeconds(.5f);
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
