using System.IO;
using UnityEngine;

namespace Utility
{
    public interface IJsonGameSave : IGameSave
    {
        void IGameSave.Save(string folder) => SaveData(folder, this);

        void IGameSave.Load(string folder) => LoadData(folder, this);

        public static void SaveData(string folder, object obj)
        {
            var json = JsonUtility.ToJson(obj);
            var file = folder + obj.GetType().Name + ".json";
            File.WriteAllText(file, json);
        }

        public static void LoadData(string folder, object obj)
        {
            var file = folder + obj.GetType().Name + ".json";
            var json = File.ReadAllText(file);
            JsonUtility.FromJsonOverwrite(json, obj);
        }
    }
}