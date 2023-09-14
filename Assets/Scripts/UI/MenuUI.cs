using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KingOfHill
{
    public class MenuUI : AdvancedUI
    {
        [SerializeField]
        private Button _openMenu;
        [SerializeField]
        private Button _continue;
        [SerializeField]
        private Button _newGame;
        [SerializeField]
        private Button _settings;
        [SerializeField]
        private Button _exit;
        public Action OnOpenSettings;
        private TimeScaler _timeScaler;
        private static MenuUI _instance;

        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeMethodLoad()
        {
            _instance._continue.gameObject.SetActive(false);
            _instance.ShowPanel(() => new TimeScaler().Change(0));
        }

        public void Init(SettingsUI settingsUI)
        {
            _instance = this;
            _timeScaler = new TimeScaler();
            SetActive(false);

            _openMenu.onClick.AddListener(() => 
            ShowPanel(() =>_timeScaler.Change(0)));

            settingsUI.OnExit += () =>
            ShowPanel(null);

            _continue.onClick.AddListener(() =>
            ClosePanel(_continue, () => _timeScaler.Change(1)));

            _newGame.onClick.AddListener(() =>
            ClosePanel(_newGame, () => 
            { 
                _timeScaler.Change(1); 
                new SceneChanger(Scenes.Game); 
            }));

            _settings.onClick.AddListener(() =>
            ClosePanel(_settings, () => OnOpenSettings?.Invoke()));

            _exit.onClick.AddListener(() =>
            ClosePanel(_exit, () => Application.Quit()));
        }
    }
}

