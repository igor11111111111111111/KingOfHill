using CustomJson;
using System;

namespace KingOfHill
{
    [Serializable]
    public class SettingsSaveData : ISaveData
    {
        public float MusicVolume;
        public float SoundsVolume;

        public SettingsSaveData(float musicVolume, float soundsVolume)
        {
            MusicVolume = musicVolume;
            SoundsVolume = soundsVolume;
        }
    }
}

