using CustomJson;
using System;
using System.Collections.Generic;

namespace KingOfHill
{
    public class ScoreSaveSystem
    {
        public ScoreSaveSystem(UI ui, ScoreData data)
        {
            ui.SaveScoreUI.OnEnterName += (name) =>
            {
                var json = new Json();
                var saveData = json.Load<ScoreSaveData>();
                if (saveData== null)
                {
                    CreateRecordHolders();
                }
                saveData.List.Add(new NameScoreData(name, data.Value));
                json.Save(saveData);

                ui.AllPlayersScoreUI.Show(saveData);
            };
        }

        private ScoreSaveData CreateRecordHolders()
        {
            var saveData = new ScoreSaveData();
            saveData.List = new List<NameScoreData>()
            {
                new NameScoreData("Vasya", 23),
                new NameScoreData("Petya", 1),
                new NameScoreData("Natasha", 500),
                new NameScoreData("Nikita", 999),
                new NameScoreData("Maksim", 4)
            };
            return saveData;
        }
    }
} 


