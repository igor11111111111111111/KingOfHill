using System;
using UnityEngine;

namespace KingOfHill
{
    public class CollisionChecker : MonoBehaviour
    {
        public Action OnCollision;
        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke();
        }
    }
}

