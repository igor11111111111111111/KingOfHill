using CustomJson;
using System;
using System.Collections.Generic;

namespace KingOfHill
{
    [Serializable]
    public class ScoreSaveData : ISaveData
    {
        public List<NameScoreData> List;
    }
}

