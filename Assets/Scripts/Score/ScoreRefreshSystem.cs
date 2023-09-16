using System;
using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class ScoreRefreshSystem
    {
        [Inject]
        private void Init(ScoreData data, Player player, UI ui)
        {
            player.Trigger.OnLandedNewRung += () =>
            {
                data.Value++;
                ui.CurrentScoreUI.Refresh(data.Value);
            };
        }
    }
} 

