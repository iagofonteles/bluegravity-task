#if YAMLDOTNET
using System.IO;
using YamlDotNet.Serialization;

namespace Utility
{
    public interface IYamlGameSave : IGameSave
    {
        void IGameSave.Save(string folder) => SaveData(folder, this);

        object IGameSave.Load(string folder) => LoadData(folder, this);

        public static void SaveData(string folder, object obj)
        {
            var serializer = new Serializer();
            var yaml = serializer.Serialize(obj);
            var file = folder + obj.GetType().Name + ".yaml";
            File.WriteAllText(file, yaml);
        }

        public static object LoadData(string folder, object obj)
        {
            var file = folder + obj.GetType().Name + ".yaml";
            if (!File.Exists(file)) return obj;
            var yaml = File.ReadAllText(file);
            var deserializer = new Deserializer();
            return deserializer.Deserialize(yaml, obj.GetType());
        }
    }
}
#endif