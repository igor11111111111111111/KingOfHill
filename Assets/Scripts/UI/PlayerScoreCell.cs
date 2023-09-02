using TMPro;
using UnityEngine;

namespace KingOfHill
{
    public class PlayerScoreCell : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _score;

        public void Init(NameScoreData data)
        {
            _name.text = data.Name;
            _score.text = data.Score.ToString();
        }
    } 
} 


