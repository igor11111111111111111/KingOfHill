using CustomJson;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace KingOfHill
{
    public class ScoreSaveSystem
    {
        public ScoreSaveSystem(SaveScoreUI saveScoreUI, ScoreData data)
        {
            saveScoreUI.OnEnterName += (name) =>
            {
                var json = new Json();
                var saveData = json.Load<ScoreSaveData>();
                saveData.List.Add(new NameScoreData(name, data.Value));
                json.Save(saveData);
            };
        }
    }
} 


