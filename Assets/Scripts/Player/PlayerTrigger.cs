using System;
using UnityEngine;

namespace KingOfHill
{
    public class PlayerTrigger : MonoBehaviour
    {
        public Action OnGameOver;
        public Action OnLandedNewRung;
        private Rigidbody _rigidbody;
        public bool IsGrounded => _isGrounded;
        private bool _isGrounded;
        private Rung _oldRung;

        public PlayerTrigger Init(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;

            return this;
        }

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

            if (other.TryGetComponent(out DeathArea area) || 
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

