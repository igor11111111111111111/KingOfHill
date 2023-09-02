using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KingOfHill
{
    public class SaveScoreUI : MonoBehaviour
    {
        public Action<string> OnEnterName;
        [SerializeField]
        private TMP_InputField _inputField;
        [SerializeField]
        private Button _accept;
        
        public void Init()
        {
            SetActive(false);
            _accept.onClick.AddListener(() =>
            {
                OnEnterName?.Invoke(_inputField.text);
                SetActive(false);
            });
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
} 


