using System.IO;
using UnityEngine;

namespace Utility
{
    public interface IJsonGameSave : IGameSave
    {
        void IGameSave.Save(string folder) => SaveData(folder, this);

        object IGameSave.Load(string folder) => LoadData(folder, this);

        public static void SaveData(string folder, object obj)
        {
            var json = JsonUtility.ToJson(obj, true);
            var file = folder + obj.GetType().Name + ".json";
            File.WriteAllText(file, json);
        }

        public static object LoadData(string folder, object obj)
        {
            var file = folder + obj.GetType().Name + ".json";
            if (!File.Exists(file)) return obj;
            var json = File.ReadAllText(file);
            JsonUtility.FromJsonOverwrite(json, obj);
            return obj;
        }
    }
}