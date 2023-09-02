using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KingOfHill
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField]
        private Button _restart;
        [SerializeField]
        private TextMeshProUGUI _info;

        public void Init(PlayerTrigger trigger, ScoreData data)
        {
            SetActive(false);
            trigger.OnGameOver += () =>
            {
                _info.text = "Your score: " + data.Value + "\n Save it?";
                SetActive(true);
            };

            _restart.onClick.AddListener(()=> SceneManager.LoadScene("Game"));
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
} 


