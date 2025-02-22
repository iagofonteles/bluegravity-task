using System;
using BlueGravity;
using UnityEngine.EventSystems;
using ViewUtility;

namespace Inventory.UI
{
    public class SlotController : DataView<ISlot>
    {
        protected override void Subscribe(ISlot data) { }
        protected override void Unsubscribe(ISlot data) { }

        public void SetItem(PointerEventData e)
            => SetItem(e.pointerDrag.GetComponent<DataView>());

        public void SetItem(DataView view)
        {
            var data = view.GetData();
            if (data is ISlot slot) Data.Item = slot.Item;
            else Data.Item = data as ItemSO;
        }

        public void SwapSlotContent(PointerEventData e)
        {
            var otherData = e.pointerDrag.GetComponent<DataView>()?.GetData();
            if (Data == null || otherData is not ISlot other)
                throw new Exception("Invalid Data");

            var item = Data.Item;
            var amount = Data.Amount;
            var favorite = Data.Favorite;
            Data.Item = other.Item;
            Data.Amount = other.Amount;
            Data.Favorite = other.Favorite;
            other.Item = item;
            other.Amount = amount;
            other.Favorite = favorite;
        }
    }
}