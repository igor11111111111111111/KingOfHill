using UnityEngine;
using Zenject;

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

        [Inject]
        private void Init(Player player, ScoreData scoreData, SoundManager soundManager, ScoreSaveSystem scoreSaveSystem)
        {
            _gameOverUI.Init(player.Trigger, scoreData);
            _saveScoreUI.Init(_gameOverUI);
            _allPlayersScoreUI.Init(scoreSaveSystem);
            _settingsUI.Init(_menuUI, soundManager);
            _menuUI.Init(_settingsUI);

            GetComponent<UISoundSystem>().Init(player.Trigger);
        }
    } 
}

