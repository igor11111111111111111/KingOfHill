using System;
using System.Collections;
using UnityEngine;

namespace KingOfHill
{
    public class Player : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public PlayerTrigger Trigger => _trigger;
        private PlayerTrigger _trigger;

        public Player Init(MobileInput input)
        {
            _rigidbody = GetComponent<Rigidbody>();

            _trigger = gameObject
                .AddComponent<PlayerTrigger>()
                .Init(_rigidbody);

            gameObject
                .AddComponent<PlayerMoveSystem>()
                .Init(input, _rigidbody, _trigger);

            _trigger.OnGameOver += () =>
            {
                Destroy(gameObject);
            };

            return this;
        }
    }
}

