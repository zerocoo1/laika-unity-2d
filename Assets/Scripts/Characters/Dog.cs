using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Dog : Character
    {
        protected override void OnAwake()
        {
            base.OnAwake();

            MoveSpeed = 3f;
        }
    }
}
