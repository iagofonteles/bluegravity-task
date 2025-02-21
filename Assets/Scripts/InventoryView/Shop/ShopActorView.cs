using ViewUtility;

namespace Inventory.UI
{
    public class ShopActorView : DataView<IShopActor>
    {
        public DataView inventoryView;
        public DataView moneyView;

        protected override void Subscribe(IShopActor data)
        {
            inventoryView.TrySetData(data.Inventory);
            moneyView.TrySetData(data.Money);
        }

        protected override void Unsubscribe(IShopActor data)
        {
            inventoryView.TrySetData(null);
            moneyView.TrySetData(null);
        }
    }
}