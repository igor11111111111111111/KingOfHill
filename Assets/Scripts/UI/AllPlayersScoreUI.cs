using CustomJson;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KingOfHill
{
    public class AllPlayersScoreUI : AdvancedUI
    {
        private PlayerScoreCell _playerScoreCellPrefab;
        [SerializeField]
        private Transform _parent;
        [SerializeField]
        private Button _restart;

        public void Init(SaveScoreUI saveScoreUI)
        {
            SetActive(false);

            _playerScoreCellPrefab = Resources.Load<PlayerScoreCell>(nameof(PlayerScoreCell));

            saveScoreUI.OnEnterName += (_) => ShowPanel(() => Show());

            _restart.onClick.AddListener(() =>
            ClosePanel(_restart, () => new SceneChanger(Scenes.Game)));
        }

        public void Show()
        {
            var json = new Json();
            var saveData = json.Load<ScoreSaveData>();

            var sortedData = saveData.List.OrderByDescending(data => data.Score);
            foreach (var data in sortedData)
            {
                Instantiate(_playerScoreCellPrefab, _parent)
                    .Init(data);
            }
        }
    }
} 


