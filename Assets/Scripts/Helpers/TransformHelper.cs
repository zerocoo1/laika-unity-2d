using UnityEngine;
using System.Collections;
using System;

namespace Laika
{
    public static class TransformHelper
    {
        public static float AngleBetwineTwoTransforms(Transform transformA, Transform transformB)
        {
            Vector3 direction = transformA.position - transformB.position;
            float angle = Vector3.Angle(direction, transformB.forward);
            return angle;
        }

        public static float DistanceBetwineTwoTransforms(Transform transformA, Transform transformB)
        {
            float distance = Vector3.Distance(transformA.position, transformB.position);
            return distance;
        }

        /// <summary>
        /// pointByRay;
        /// </summary>
        public static Vector3 PointByRay(Ray ray, Action<Vector3> callback)
        {
            Vector3 point = Vector3.zero;

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                point = hitInfo.point;
            }

            callback(point);

            return point;
        }

        public static Vector3 PointByRay(Ray ray)
        {
            Vector3 point = Vector3.zero;

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                point = hitInfo.point;
            }

            return point;
        }

        public static void RotateTo(Transform transform, Vector3 targetPoint, float speed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.smoothDeltaTime);
        }
    }
}
