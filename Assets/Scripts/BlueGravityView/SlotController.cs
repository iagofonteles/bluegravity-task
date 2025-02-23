using System;
using BlueGravity;
using BlueGravity.UI;
using UnityEngine.EventSystems;
using Utility;
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
            if (Data == null) return;
            var otherData = e.pointerDrag.GetComponent<DataView>()?.GetData();

            if (otherData is Observable<ItemSO> equipSlot)
            {
                Unnequip(equipSlot);
                return;
            }

            if (otherData is not ISlot other)
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

        private void Unnequip(Observable<ItemSO> equipSlot)
        {
            if (equipSlot.Value == null) return;

            var inventory = GetComponentInParent<PlayerView>()?.Data.Inventory;
            if (inventory == null || !inventory.Fits(equipSlot.Value, 1)) return;

            inventory.Add(equipSlot.Value, 1);
            equipSlot.Value = null;
        }
    }
}