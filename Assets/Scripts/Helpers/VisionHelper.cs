using UnityEngine;
using System.Collections;
using System;

namespace Laika
{
    public static class VisionHelper
    {
        public static void Vision(float visionRadius, Transform transform, LayerMask targetLayerMask, Action success, Action failed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, visionRadius, targetLayerMask);

            if (hitColliders.Length == 0)
            {
                failed();
            }
            else
            {
                success();
            }
        }

        public static void Vision2D(float visionRadius, Transform transform, LayerMask targetLayerMask, Action<Transform> success, Action failed)
        {

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, visionRadius, targetLayerMask);

            if (hitColliders.Length == 0)
            {
                if (failed != null) failed();
            }
            else
            {
                foreach (var collider in hitColliders)
                {
                    success(collider.transform);
                }
            }
        }
    }
}
