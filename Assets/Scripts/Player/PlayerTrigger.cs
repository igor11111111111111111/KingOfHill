using System;
using UnityEngine;

namespace KingOfHill
{
    public class PlayerTrigger : MonoBehaviour
    { 
        public Action OnGameOver;
        public Action OnLandedNewRung;
        public bool IsGrounded => _isGrounded;
        private bool _isGrounded;
        private Rung _oldRung;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Rung trigger))
            {
                _isGrounded = true;

                if (_oldRung != trigger)
                {
                    OnLandedNewRung?.Invoke();
                }
                _oldRung = trigger;
            }

            if (other.TryGetComponent(out PlayerDeathArea area) || 
                other.TryGetComponent(out Enemy enemy))
            {
                OnGameOver?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Rung rung))
            {
                _isGrounded = false;
            }
        }
    }
}

