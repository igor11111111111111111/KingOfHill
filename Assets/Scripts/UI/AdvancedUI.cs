using UnityEngine;

namespace KingOfHill
{
    public abstract class AdvancedUI : MonoBehaviour
    {
        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
} 


