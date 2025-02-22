using System;
using System.Linq;
using BlueGravity.ItemScripts;
using Inventory;
using UnityEngine.EventSystems;
using Utility;
using ViewUtility;

namespace BlueGravity.UI
{
    public class PlayerController : DataView<Player>
    {
        protected override void Subscribe(Player data) { }
        protected override void Unsubscribe(Player data) { }

        public void EquipItem(PointerEventData e)
        {
            var data = e.pointerDrag.GetComponent<DataView>()?.GetData();
            var item = data is Slot<ItemSO> s ? s.Item : data as ItemSO;
            if (item) EquipItem(item);
        }

        public void UnequipItem(DataView equipSlotView)
        {
            var slot = equipSlotView.GetData<Observable<ItemSO>>();
            if (!Data.Inventory.Fits(slot.Value, 1)) return;
            Data.Inventory.Add(slot.Value, 1);
            slot.Value = null;
        }

        public void EquipItem(ItemSO item)
        {
            var equip = item.GetScript<Equipment>();
            if (equip == null) return;

            var slot = Data.Equipments[(int)equip.Slot];
            if (slot.Value) Data.Inventory.Add(slot.Value, 1);

            Data.Inventory.Remove(item, 1);
            slot.Value = item;
        }

        public void UnequipItem(ItemSO item)
        {
            var index = Array.IndexOf(Data.Equipments, item);
            if (index < 0) return;

            Data.Inventory.Add(item, 1);
            Data.Equipments[index].Value = null;
        }
    }
}