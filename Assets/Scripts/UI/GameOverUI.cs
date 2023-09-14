using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace KingOfHill
{
    public class GameOverUI : AdvancedUI
    {
        [SerializeField]
        private Button _restart;
        [SerializeField]
        private Button _saveScore;
        [SerializeField]
        private TextMeshProUGUI _info;
        public Action OnSaveClick;

        public void Init(PlayerTrigger trigger, ScoreData data)
        {
            SetActive(false);

            trigger.OnGameOver += () => ShowPanel(() => 
            _info.text = "Your score: " + data.Value + "\n Save it?");

            _saveScore.onClick.AddListener(() =>
            ClosePanel(_saveScore, () => OnSaveClick?.Invoke())); 

            _restart.onClick.AddListener(() =>
            ClosePanel(_restart, () => new SceneChanger(Scenes.Game)));
        }
    }
} 


