using UnityEngine;

namespace KingOfHill
{
    public class TimeScaler
    {
        public void Change(float value)
        {
            Time.timeScale = value;
        }
    }
}

