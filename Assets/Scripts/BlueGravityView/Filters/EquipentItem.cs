using System;
using BlueGravity.ItemScripts;
using Inventory;
using UIUtility;
using UnityEngine;
using ViewUtility;

namespace BlueGravity.UI.DroppableFilters
{
    [Serializable]
    public class EquipentItem : IDroppableFilter
    {
        public EquipmentSlot slot;

        public bool Accepts(GameObject gameObject)
        {
            var data = gameObject.GetComponent<DataView>()?.GetData();
            var item = data is Slot<ItemSO> s ? s.Item : data as ItemSO;
            return item?.GetScript<Equipment>()?.Slot == slot;
        }
    }
}