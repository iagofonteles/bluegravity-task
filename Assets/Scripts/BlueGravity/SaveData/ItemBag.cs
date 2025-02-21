using System;
using Inventory;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class ItemBag : SlotInventory<ItemSO>, IJsonGameSave
    {
        public ItemBag() : base(20, i => i.MaxStack) { }
    }
}