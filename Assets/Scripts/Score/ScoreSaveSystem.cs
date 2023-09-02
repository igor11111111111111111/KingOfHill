using CustomJson;
using System;
using System.Collections.Generic;

namespace KingOfHill
{
    public class ScoreSaveSystem
    {
        public ScoreSaveSystem(SaveScoreUI scoreUI, AllPlayersScoreUI allPlayersScoreUI, ScoreData data)
        {
            scoreUI.OnEnterName += (name) =>
            {
                var json = new Json();
                var saveData = json.Load<ScoreSaveData>();
                if (saveData== null)
                {
                    saveData = new ScoreSaveData();
                    saveData.List = new List<NameScoreData>()
                    {
                        new NameScoreData("Vasya", 23),
                        new NameScoreData("Petya", 1),
                        new NameScoreData("Natasha", 500),
                        new NameScoreData("Nikita", 999),
                        new NameScoreData("Maksim", 4)
                    };
                }
                saveData.List.Add(new NameScoreData(name, data.Value));
                json.Save(saveData);

                allPlayersScoreUI.Show(saveData);
            };
        }
    }
} 


