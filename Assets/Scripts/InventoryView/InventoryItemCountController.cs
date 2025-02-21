using UnityEngine.EventSystems;
using ViewUtility;

namespace Inventory.UI
{
    public class InventoryItemCountView : DataView<ISlot>
    {
        protected override void Subscribe(ISlot data) { }
        protected override void Unsubscribe(ISlot data) { }

        public void SetItem(PointerEventData e)
            => SetItem(e.pointerDrag.GetComponent<DataView>());

        public void SetItem(DataView view)
        {
            var data = view?.GetData();
            if (data is ISlot slot) Data.Item = slot.Item;
            else Data.Item = data;
        }
    }
}