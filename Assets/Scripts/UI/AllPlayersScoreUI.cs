using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KingOfHill
{
    public class AllPlayersScoreUI : MonoBehaviour
    {
        [SerializeField]
        private PlayerScoreCell _playerScoreCellPrefab;
        [SerializeField]
        private Transform _parent;
        [SerializeField]
        private Button _restart;

        public void Init()
        {
            SetActive(false);
            _restart.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        }

        public void Show(ScoreSaveData scoreSaveData)
        {
            var sortedData = scoreSaveData.List.OrderByDescending(data => data.Score);
            foreach (var data in sortedData)
            {
                Instantiate(_playerScoreCellPrefab, _parent)
                    .Init(data);
            }
            SetActive(true);
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
} 


