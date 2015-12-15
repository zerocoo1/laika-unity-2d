using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Cow : Character
    {
        public LayerMask CowLayerMask;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Vision()
        {
            VisionHelper.Vision(3f, transform, CowLayerMask, () =>
            {
                
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

            MoveSpeed = 1.5f;
            StartCoroutine(CheckVision());
        }
    }
}
