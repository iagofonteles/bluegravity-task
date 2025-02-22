using Inventory;
using UIUtility;
using UnityEngine;
using ViewUtility;
using BlueGravity.ItemScripts;

namespace BlueGravity.UI.DroppableFilters
{
    public class UsableItemOrSlot : IDroppableFilter
    {
        public bool Accepts(GameObject gameObject)
        {
            var data = gameObject.GetComponent<DataView>()?.GetData();
            var item = data is Slot<ItemSO> s ? s.Item : data as ItemSO;
            return item?.GetScript<IUsabeItem>() != null;
        }
    }
}