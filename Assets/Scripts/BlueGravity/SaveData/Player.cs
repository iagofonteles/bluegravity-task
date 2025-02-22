using System;
using System.Linq;
using Inventory;
using Utility;
using BlueGravity.ItemScripts;
using UnityEngine;
using YamlDotNet.Serialization;

namespace BlueGravity
{
    public partial class Player : IShopActor
    {
        [SerializeField] private SlotInventory<ItemSO> inventory = new(20, i => i.MaxStack);
        
        public string DisplayName { get; private set; }
        public Observable<int> Money { get; private set; } = new();
        public Observable<ItemSO>[] Equipments { get; private set; } = { new(), new(), new() };
        
        [YamlIgnore] public InventoryItemCounter[] Hotbar { get; private set; } = new InventoryItemCounter[5];
        [YamlIgnore] public SlotInventory<ItemSO> Inventory => inventory; 
        [YamlIgnore] public CharacterStats Stats { get; private set; } = new();

        IInventory IShopActor.Inventory => Inventory;

        public Player()
        {
            for (int i = 0; i < Hotbar.Length; i++)
                Hotbar[i] = new(Inventory);

            foreach (var equip in Equipments)
                equip.OnChanged += RecalculateStats;
        }

        public void RecalculateStats(object _)
        {
            var equips = Equipments.Select(i => i.Value?.GetScript<Equipment>()).ToArray();
            Stats.MiningPower.Value = 1 + equips.Sum(i => i?.MininPower ?? 0);
            Stats.MoveSpeed.Value = 1 + equips.Sum(i => i?.MoveSpeedMultiplier ?? 0);
        }
    }
}