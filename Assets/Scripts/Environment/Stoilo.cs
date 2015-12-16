using UnityEngine;
using System.Collections;

namespace Laika
{
    public class Stoilo : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            IChill chill = other.transform.GetComponent<IChill>();

            if (chill != null)
            {
                chill.TakeChill();
                GameManager.Instance.IncreasScore();
            }
        }
    }
}
