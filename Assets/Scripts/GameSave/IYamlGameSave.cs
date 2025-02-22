#if YAMLDOTNET
using System.IO;
using YamlDotNet.Serialization;

namespace Utility
{
    public interface IYamlGameSave : IGameSave
    {
        void IGameSave.Save(string folder) => SaveData(new Serializer(), folder, this);

        IGameSave IGameSave.Load(string folder) => LoadData(new Deserializer(), folder, this);

        public static void SaveData(ISerializer serializer, string folder, object obj)
        {
            var yaml = serializer.Serialize(obj);
            var file = folder + obj.GetType().Name + ".yaml";
            File.WriteAllText(file, yaml);
        }

        public static IGameSave LoadData(IDeserializer deserializer, string folder, IGameSave obj)
        {
            var file = folder + obj.GetType().Name + ".yaml";
            if (!File.Exists(file)) return obj;
            var yaml = File.ReadAllText(file);
            return (IGameSave)deserializer.Deserialize(yaml, obj.GetType());
        }
    }
}
#endif