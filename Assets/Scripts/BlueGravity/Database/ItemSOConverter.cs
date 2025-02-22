using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace BlueGravity.Serialization
{
    public class ItemSOConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type) => type == typeof(ItemSO);

        public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
        {
            var name = parser.Consume<Scalar>().Value;
            return Game.Database.Get<ItemSO>(name);
        }

        public void WriteYaml(IEmitter emitter, object value, Type type, ObjectSerializer serializer)
        {
            var name = (value as ItemSO)?.name;
            emitter.Emit(new Scalar(name ?? ""));
        }
    }
}