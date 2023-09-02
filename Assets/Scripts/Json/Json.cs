using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CustomJson
{
    public class Json
    {
        public void Save<T>(T data) where T : ISaveData
        {
            string contents = JsonConvert.SerializeObject(data, Formatting.Indented);
            string path = Application.persistentDataPath + "/Score.json";
            File.WriteAllText(path, contents);
        }

        public T Load<T>() where T : ISaveData
        {
            string path = Application.persistentDataPath + "/Score.json";

            if (!File.Exists(path))
                return default(T);

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
