using BlueGravity;
using BlueGravity.ItemScripts;
using ViewUtility;

namespace Inventory.UI
{
    public class ItemController : DataView<ItemSO>
    {
        public void UseItem(DataView playerView)
        {
            if (playerView.GetData() is not Player player) return;
            var used = Data.GetScript<IUsabeItem>()?.TryUse(player);
            if (used ?? false) player.Inventory.Remove(Data, 1);
        }

        protected override void Subscribe(ItemSO data) { }
        protected override void Unsubscribe(ItemSO data) { }
    }
}