using System;
using Inventory;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace BlueGravity.Serialization
{
    public class ItemSOSlotConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type) => type == typeof(Slot<ItemSO>);

        public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
        {
            var str = parser.Consume<Scalar>().Value.Split(',');
            var fav = bool.Parse(str[0]);
            var amt = int.Parse(str[1]);
            var itm = Game.Database.Get<ItemSO>(str[2]);

            return new Slot<ItemSO>()
            {
                Favorite = fav,
                Item = itm,
                Amount = amt,
            };
        }

        public void WriteYaml(IEmitter emitter, object value, Type type, ObjectSerializer serializer)
        {
            var slot = value as Slot<ItemSO>;
            var fav = slot.Favorite.ToString();
            var amt = slot.Amount.ToString();
            var itm = slot.Item?.name ?? "";

            emitter.Emit(new Scalar($"{fav},{amt},{itm}"));
        }
    }
}