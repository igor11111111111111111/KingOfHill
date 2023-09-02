using TMPro;
using UnityEngine;

namespace KingOfHill
{
    public class CurrentScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void Refresh(int value)
        {
            _text.text = value.ToString();
        }
    }
}

