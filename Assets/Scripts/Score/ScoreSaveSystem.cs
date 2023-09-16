using CustomJson;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class ScoreSaveSystem
    {
        public Action OnSaved;

        [Inject]
        private void Init(ScoreData data, UI ui)
        {
            ui.SaveScoreUI.OnEnterName += (name) =>
            {
                var json = new Json();
                var saveData = json.Load<ScoreSaveData>();
                saveData.List.Add(new NameScoreData(name, data.Value));
                json.Save(saveData);
                OnSaved?.Invoke();
            };
        }
    }
} 


