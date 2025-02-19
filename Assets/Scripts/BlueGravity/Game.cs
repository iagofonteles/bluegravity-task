using System.IO;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    public static class Game
    {
        public static GameSave Save;

        static Game()
        {
            var saveFolder = Path.Combine(Application.persistentDataPath, "Saves");
            Save = new GameSave(saveFolder);
        }

        [RuntimeInitializeOnLoadMethod]
        static void InitTypeCache()
        {
            TypeCache.SetAssemblies(new[] { typeof(Item).Assembly });
        }
    }
}