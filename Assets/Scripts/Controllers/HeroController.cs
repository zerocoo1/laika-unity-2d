using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laika
{
    public class HeroController : MonoBehaviour
    {
        /// <summary>
        /// Public params:
        /// </summary>

        public Character Dog;
        public LayerMask HeroWallkMask;

        public void ActivateDogWithId(int id)
        {
            foreach (var dog in _dogsList)
            {
                dog.DogReceiveCommands(false || dog.DogId == id);
            }
        }

        private List<Dog> _dogsList;

        /// <summary>
        /// Private methods:
        /// </summary>

        private void Start()
        {
            _dogsList = FindObjectsOfType<Dog>().ToList();
            ActivateDogWithId(0);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                MoveHero();
            }
        }

        private void MoveHero()
        {
            int fingerId = -1;

            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(fingerId)) return;
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mousePosition, 20f, HeroWallkMask);
            
            if (!hit) return;

            if (hit.collider.CompareTag("Walkable"))
            {
                BroadcastMessage("SetDestination", hit.point);
            }
        }
    }
}
