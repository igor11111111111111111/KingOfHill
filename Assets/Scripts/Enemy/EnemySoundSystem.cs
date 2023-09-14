using UnityEngine;

namespace KingOfHill
{
    public class EnemySoundSystem
    {
        public EnemySoundSystem(AudioSource audioSource, CollisionChecker collisionChecker)
        {
            collisionChecker.OnCollision += () =>
            {
                audioSource.Play();
            };
        }
    }
}

