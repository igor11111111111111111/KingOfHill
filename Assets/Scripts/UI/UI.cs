using UnityEngine;

namespace KingOfHill
{
    public class UI : MonoBehaviour
    {
        public CurrentScoreUI CurrentScoreUI => _currentScoreUI;
        [SerializeField]
        private CurrentScoreUI _currentScoreUI;

        public SaveScoreUI SaveScoreUI => _saveScoreUI;
        [SerializeField]
        private SaveScoreUI _saveScoreUI;

        public AllPlayersScoreUI AllPlayersScoreUI => _allPlayersScoreUI;
        [SerializeField]
        private AllPlayersScoreUI _allPlayersScoreUI;

        [SerializeField]
        private GameOverUI _gameOverUI;
        [SerializeField]
        private MenuUI _menuUI;
        [SerializeField]
        private SettingsUI _settingsUI;

        public void Init(PlayerTrigger trigger, ScoreData scoreData)
        {
            _gameOverUI.Init(trigger, scoreData);
            _saveScoreUI.Init(_gameOverUI);
            _allPlayersScoreUI.Init(_saveScoreUI);
            _settingsUI.Init(_menuUI);
            _menuUI.Init(_settingsUI);

            GetComponent<UISoundSystem>().Init(trigger);
        }
    } 
}

