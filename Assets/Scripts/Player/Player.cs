using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace KingOfHill
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particle;
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

            var audioSource = GetComponent<AudioSource>();
            new PlayerSoundSystem(audioSource, _trigger);

            _trigger.OnGameOver += () =>
            {
                _particle.transform.SetParent(null);
                _particle.Play();
                Destroy(gameObject);
            };

            return this;
        }
    }
}

