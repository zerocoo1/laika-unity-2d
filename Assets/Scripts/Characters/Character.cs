using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Character : MonoBehaviour
    {
        protected Vector3 TargetPoint;

        protected float MoveSpeed = 1f;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Awake()
        {
            TargetPoint = transform.position;

            OnAwake();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        private void SetDestination(Vector2 point)
        {
            OnSetDestination(point);
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected virtual void OnAwake()
        {
            
        }

        protected virtual void OnFixedUpdate()
        {
            Move();
        }

        protected virtual void OnSetDestination(Vector2 point)
        {
            TargetPoint = point;
        }

        protected void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPoint, MoveSpeed * Time.deltaTime);
        }
    }
}
