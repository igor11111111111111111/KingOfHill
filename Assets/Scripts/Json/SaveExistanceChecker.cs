using CustomJson;
using System.Collections.Generic;

namespace KingOfHill
{
    public class SaveExistanceChecker
    {
        public SaveExistanceChecker()
        {
            var json = new Json();
            Score(json);
            Settings(json);
        }

        private void Settings(Json json)
        {
            var settingsData = json.Load<SettingsSaveData>();
            if (settingsData == null)
            {
                settingsData = new SettingsSaveData(0.3f, 0.3f);
                json.Save(settingsData);
            }
        }

        private void Score(Json json)
        {
            var scoreData = json.Load<ScoreSaveData>();
            if (scoreData == null)
            {
                scoreData = new ScoreSaveData();
                scoreData.List = new List<NameScoreData>()
                {
                    new NameScoreData("Vasya", 23),
                    new NameScoreData("Petya", 1),
                    new NameScoreData("Natasha", 500),
                    new NameScoreData("Nikita", 999),
                    new NameScoreData("Maksim", 4)
                };
                json.Save(scoreData);
            };
        }
    }
}

