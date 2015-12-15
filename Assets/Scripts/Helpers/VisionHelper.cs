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
    }
}
