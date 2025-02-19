using Inventory;
using Utility;

namespace BlueGravity
{
    public class ItemBag : SlotInventory<Item>, IJsonGameSave
    {
        public ItemBag() : base(20, i => i.MaxStack) { }
    }
}