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
            File.WriteAllText(GetPath<T>(), contents);
        }

        public T Load<T>() where T : ISaveData
        {
            string path = GetPath<T>();
            if (!File.Exists(path))
                return default(T);
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string GetPath<T>() where T : ISaveData
        {
            return Application.persistentDataPath + "/" + typeof(T).Name + ".json";
        }
    }
}
