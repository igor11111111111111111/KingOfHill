using CustomJson;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace KingOfHill
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audio;
        [SerializeField]
        private AudioMixerGroup _audioMixerGroup;

        [Inject]
        private async void Init()
        {
            _audio = GetComponent<AudioSource>();
            var data = LoadData();
            await Task.Delay(10);
            SetMusicVolume(data.MusicVolume);
            SetSoundVolume(data.SoundsVolume);
            _audio.Play();
        }

        private SettingsSaveData LoadData()
        {
            var json = new Json();
            var saveData = json.Load<SettingsSaveData>();
            return saveData;
        }

        public void SetMusicVolume(float value)
        {
            SetVolume("Music", value);
        }

        public void SetSoundVolume(float value)
        {
            SetVolume("Sounds", value);
        }

        private void SetVolume(string name, float value)
        {
            if (value == 0)
            {
                _audioMixerGroup.audioMixer.SetFloat(name, -80);
                return;
            }
            _audioMixerGroup.audioMixer.SetFloat(name, Mathf.Log10(value) * 30);
        }
    }
}

