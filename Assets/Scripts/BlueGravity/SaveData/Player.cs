using System.Linq;
using Inventory;
using UnityEngine;
using Utility;
using BlueGravity.ItemScripts;

namespace BlueGravity
{
    public partial class Player : IShopActor
    {
        [SerializeField] private string displayName;
        [SerializeField] private Vector3 position;
        [SerializeField] private CharacterStats stats = new();
        [SerializeField] private Observable<int> money = new();
        [SerializeField] private SlotInventory<ItemSO> inventory = new(20, i => i.MaxStack);

        private readonly Observable<ItemSO>[] _equipments = { new(), new(), new() };
        private readonly InventoryItemCounter[] _hotbar = new InventoryItemCounter[10];

        public string DisplayName => displayName;
        public Vector3 Position => position;
        public CharacterStats Stats => stats;
        public Observable<int> Money => money;
        public SlotInventory<ItemSO> Inventory => inventory;
        public Observable<ItemSO>[] Equipments => _equipments;
        public InventoryItemCounter[] Hotbar => _hotbar;

        IInventory IShopActor.Inventory => inventory;

        public Player()
        {
            for (int i = 0; i < _hotbar.Length; i++)
                _hotbar[i] = new(inventory);

            foreach (var equip in _equipments)
                equip.OnChanged += RecalculateStats;
        }

        public void RecalculateStats(object _)
        {
            var equips = _equipments.Select(i => i.Value.GetScript<Equipment>()).ToArray();
            stats.MiningPower.Value = 1 + equips.Sum(i => i?.MininPower ?? 0);
            stats.MoveSpeed.Value = 1 + equips.Sum(i => i?.MoveSpeedMultiplier ?? 0);
        }
    }
}