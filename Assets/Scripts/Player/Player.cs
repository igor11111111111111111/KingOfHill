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

        public Player Init(IInputSystem inputSystem)
        {
            _rigidbody = GetComponent<Rigidbody>();

            _trigger = gameObject
                .AddComponent<PlayerTrigger>();

            gameObject
                .AddComponent<PlayerMoveSystem>()
                .Init(inputSystem, _rigidbody, _trigger);

            _trigger.OnGameOver += () =>
            {
                Destroy(gameObject);
            };

            return this;
        }
    }
}

