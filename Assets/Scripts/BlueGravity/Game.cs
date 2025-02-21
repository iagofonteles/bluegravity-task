using UnityEngine;
using Utility;

namespace BlueGravity
{
    public static class Game
    {
        public static GameSave Save;

        static Game()
        {
            var dataPath = Application.isEditor ? Application.dataPath + "/.." : Application.persistentDataPath;
            var saveFolder = dataPath + "/Saves";
            Debug.Log($"saveFolder: {saveFolder}");

            Save = new GameSave(saveFolder);
            Save.Load("Default");
        }
    }
}