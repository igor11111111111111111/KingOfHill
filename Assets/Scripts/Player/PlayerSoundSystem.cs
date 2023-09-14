using UnityEngine;

namespace KingOfHill
{
    public class PlayerSoundSystem
    {
        public PlayerSoundSystem(AudioSource audioSource, PlayerTrigger trigger)
        {
            trigger.OnCollision += () =>
            {
                audioSource.Play();
            };
        }
    }
}

