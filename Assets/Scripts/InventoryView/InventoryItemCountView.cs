using UnityEngine.Events;
using ViewUtility;

namespace Inventory.UI
{
    public class InventoryItemCountView : DataView<InventoryItemCounter>
    {
        public UnityEvent<object> item;
        public UnityEvent<int> amount;

        IInventory _inventory;
        private int _count;

        protected override void Subscribe(InventoryItemCounter data)
        {
            data.OnItemChanged += item.Invoke;
            data.OnAmountChanged += amount.Invoke;
        }

        protected override void Unsubscribe(InventoryItemCounter data)
        {
            data.OnItemChanged -= item.Invoke;
            data.OnAmountChanged -= amount.Invoke;
        }
    }
}