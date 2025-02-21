using System;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class GameSave
    {
        Dictionary<Type, IGameSave> _saves = new();

        public string RootFolder { get; private set; }
        public string SaveName { get; private set; }

        public event Action<GameSave> OnSaving;
        public event Action<GameSave> OnLoaded;

        public GameSave(string rootFolder)
        {
            RootFolder = rootFolder;
        }

        public T Get<T>() where T : IGameSave, new() => (T)Get(typeof(T));

        public IGameSave Get(Type type)
        {
            if (!_saves.TryGetValue(type, out var save))
            {
                save = (IGameSave)Activator.CreateInstance(type);
                save.Load(Path.Combine(RootFolder, SaveName));
                _saves[type] = save;
            }

            return save;
        }

        public void Set<T>(T saveData) where T : IGameSave
        {
            _saves[typeof(T)] = saveData;
            OnLoaded?.Invoke(this);
        }

        public void Save()
        {
            OnSaving?.Invoke(this);
            var path = Path.Combine(RootFolder, SaveName);
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var save in _saves.Values)
                save.Save(path);
        }

        public void Load(string saveName)
        {
            _saves.Clear();
            SaveName = saveName;
            OnLoaded?.Invoke(this);
        }
    }
}