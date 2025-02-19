using Inventory.Internal;
using ViewUtility;

namespace Inventory.UI
{
    public class ShopActorView : DataView<IShopActor>
    {
        public DataView inventoryView;
        public DataView moneyView;

        protected override void Subscribe(IShopActor data)
        {
            if (inventoryView) inventoryView.SetData(data.Inventory);
            if (moneyView) moneyView.SetData(data.Money);
        }

        protected override void Unsubscribe(IShopActor data)
        {
            if (inventoryView) inventoryView.SetData(null);
            if (moneyView) moneyView.SetData(null);
        }
    }
}