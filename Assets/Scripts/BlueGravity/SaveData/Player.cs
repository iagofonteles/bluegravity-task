using System;
using System.Linq;
using Inventory;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class Player : IYamlGameSave, IShopActor
    {
        [SerializeField] private string displayName;
        [SerializeField] private Vector3 position;
        [SerializeField] private CharacterStats stats = new();
        [SerializeField] private Observable<int> money = new();
        [SerializeField] private SlotInventory<ItemSO> inventory = new(20, i => i.MaxStack);
        [SerializeField] private ObservableList<ItemSO> hotbar = new(Enumerable.Repeat<ItemSO>(null, 10));

        public string DisplayName => displayName;
        public Vector3 Position => position;
        public CharacterStats Stats => stats;
        public Observable<int> Money => money;
        public SlotInventory<ItemSO> Inventory => inventory;
        public ObservableList<ItemSO> Hotbar => hotbar;

        IInventory IShopActor.Inventory => inventory;
    }
}