using CustomJson;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace KingOfHill
{
    public class SettingsUI : AdvancedUI
    {
        [SerializeField]
        private Slider _music;
        [SerializeField]
        private Slider _sound;
        [SerializeField]
        private Button _exit;
        public Action OnExit;

        public void Init(MenuUI menuUI, SoundManager soundManager)
        {
            SetActive(false);
            var json = new Json();
            var data = json.Load<SettingsSaveData>();
            _music.value = data.MusicVolume;
            _sound.value = data.SoundsVolume;

            _music.onValueChanged.AddListener((value) =>
            soundManager.SetMusicVolume(value));

            _sound.onValueChanged.AddListener((value) =>
            soundManager.SetSoundVolume(value));

            menuUI.OnOpenSettings += () => ShowPanel(null);

            _exit.onClick.AddListener(() =>
            ClosePanel(_exit, () =>
            {
                data.MusicVolume = _music.value;
                data.SoundsVolume = _sound.value;
                json.Save(data);
                OnExit?.Invoke();
            }));
        }
    }
}

