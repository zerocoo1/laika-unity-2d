using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// Protected params:
        /// </summary>

        protected Vector3 TargetPoint;
        protected float MoveSpeed = 1f;
        protected Animator Anim;

        private Vector3 _lastPosition;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Awake()
        {
            Anim = GetComponent<Animator>();
            TargetPoint = transform.position;
            _lastPosition = Camera.main.WorldToScreenPoint(transform.position);

            OnAwake();
        }

        private void FixedUpdate()
        {
            var velocity = (Camera.main.WorldToScreenPoint(transform.position) - _lastPosition);

            Anim.SetFloat("Speed", velocity.normalized.magnitude / 2f);

            _lastPosition = Camera.main.WorldToScreenPoint(transform.position);

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
