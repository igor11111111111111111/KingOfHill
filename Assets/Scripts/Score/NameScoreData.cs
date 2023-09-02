using CustomJson;
using System;

namespace KingOfHill
{
    [Serializable]
    public class NameScoreData : ISaveData
    {
        public string Name;
        public int Score;

        public NameScoreData(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}

