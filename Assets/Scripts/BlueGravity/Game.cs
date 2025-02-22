using Drafts.Internationalization;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    public static class Game
    {
        public static Database Database = new();
        public static GameSave Save;
        public static I18n I18n;

        static Game()
        {
            var dataPath = Application.isEditor ? Application.dataPath + "/.." : Application.persistentDataPath;
            var saveFolder = dataPath + "/Saves";
            Debug.Log($"saveFolder: {saveFolder}");

            Save = new GameSave(saveFolder);
            Save.Load("Default");

            var tableProvider = new AddressablesTableProvider("i18n/{1} {0}.txt");
            var fileReader = new TSVFileReader();
            I18n = new I18n("eng", tableProvider, fileReader);
        }
    }
}