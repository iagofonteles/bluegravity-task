using Inventory.Internal;
using ViewUtility;

namespace Inventory.UI
{
    public class ShopView : DataView<IShop>
    {
        public DataView merchantView;
        public DataView costumerView;

        protected override void Subscribe(IShop data)
        {
            if (merchantView) merchantView.SetData(data.Merchant);
            if (costumerView) costumerView.SetData(data.Costumer);
        }

        protected override void Unsubscribe(IShop data)
        {
            if (merchantView) merchantView.SetData(null);
            if (costumerView) costumerView.SetData(null);
        }
    }
}