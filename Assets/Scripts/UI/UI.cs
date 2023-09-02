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

        public void Init(PlayerTrigger trigger, ScoreData scoreData)
        {
            _gameOverUI.Init(trigger, scoreData);
            _saveScoreUI.Init();
            _allPlayersScoreUI.Init();
        }
    } 
}

