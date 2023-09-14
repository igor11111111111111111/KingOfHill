using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KingOfHill
{
    public class SaveScoreUI : AdvancedUI
    {
        public Action<string> OnEnterName;
        [SerializeField]
        private TMP_InputField _inputField;
        [SerializeField]
        private Button _accept;

        public void Init(GameOverUI gameOverUI)
        {
            SetActive(false);

            gameOverUI.OnSaveClick += () => ShowPanel(null);

            _accept.onClick.AddListener(() =>
            ClosePanel(_accept, () => OnEnterName?.Invoke(_inputField.text)));
        }
    }
} 


