using System;
using System.Linq;
using BlueGravity.Serialization;
using Inventory;
using Utility;
using YamlDotNet.Serialization;

namespace BlueGravity
{
    [Serializable]
    public partial class Player : IGameSave
    {
        private static ISerializer _serializer = new SerializerBuilder()
            .WithTypeConverter(new ItemSOConverter())
            .WithTypeConverter(new ItemSOSlotConverter())
            .Build();

        private static IDeserializer _deserializer = new DeserializerBuilder()
            .WithTypeConverter(new ItemSOConverter())
            .WithTypeConverter(new ItemSOSlotConverter())
            .Build();

        public Slot<ItemSO>[] _inventory { get; set; }
        public ItemSO[] _hotbar { get; set; }

        void IGameSave.Save(string folder)
        {
            _inventory = Inventory.Slots.ToArray();
            _hotbar = Hotbar.Select(s => s.Item as ItemSO).ToArray();
            IYamlGameSave.SaveData(_serializer, folder, this);
        }

        IGameSave IGameSave.Load(string folder)
        {
            var player = IYamlGameSave.LoadData(_deserializer, folder, this) as Player;

            if(player._inventory != null)
            player.Inventory.SetSlots(player._inventory);

            if(player._hotbar != null)
            for (int i = 0; i < player.Hotbar.Length; i++)
                player.Hotbar[i].Item = player._hotbar[i];

            player.RecalculateStats(null);
            return player;
        }
    }
}