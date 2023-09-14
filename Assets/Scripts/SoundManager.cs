using CustomJson;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace KingOfHill
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance {get; private set; }
        private AudioSource _audio;
        [SerializeField]
        private AudioMixerGroup _audioMixerGroup;
        private void Awake()
        {

        }
        public async void Init()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this);
                Instance = this;
                _audio = GetComponent<AudioSource>();

                await Task.Delay(100); // Для обхода древнего бага самой юнити AudioMixerGroup не поставит значение из условного Awake
                var data = LoadData();
                SetMusicVolume(data.MusicVolume);
                SetSoundVolume(data.SoundsVolume);
                _audio.Play();
            }
            else
            {
                Destroy(this);
            }
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
            SetVolume("Sound", value);
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

