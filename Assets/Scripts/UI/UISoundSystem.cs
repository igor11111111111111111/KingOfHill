using UnityEngine;

namespace KingOfHill
{
    public class UISoundSystem : MonoBehaviour
    {
        private AudioSource _audioSource;

        public void Init(PlayerTrigger trigger)
        {
            var audioSource = GetComponent<AudioSource>();
            trigger.OnGameOver += () =>
            {
                var clip = Resources.Load<AudioClip>("Sounds/GameOver");
                audioSource.clip = clip;
                audioSource.Play();
            };
            _audioSource = audioSource;
        }

        public void PlayButtonClick()
        {
            var clip = Resources.Load<AudioClip>("Sounds/ButtonClick");
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}

