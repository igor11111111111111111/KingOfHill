using System;
using UnityEngine;

namespace KingOfHill
{
    public class ScoreRefreshSystem
    {
        public ScoreRefreshSystem(ScoreData data, PlayerTrigger trigger, CurrentScoreUI uI)
        {
            trigger.OnLandedNewRung += () =>
            {
                data.Value++;
                uI.Refresh(data.Value);
            };
        }
    }
} 

