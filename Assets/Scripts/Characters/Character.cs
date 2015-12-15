using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Character : MonoBehaviour
    {
        private Vector3 _target;

        protected float MoveSpeed = 2f;

        /// <summary>
        /// Public methods:
        /// </summary>

        public void SetDestination(Vector3 point)
        {
            _target = point;
            _target.z = transform.position.z;
        }

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Awake()
        {
            _target = transform.position;

            OnAwake();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, MoveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Protected methods:
        /// </summary>

        protected virtual void OnAwake()
        {
            
        }
    }
}
