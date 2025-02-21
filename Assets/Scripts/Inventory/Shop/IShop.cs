using System;

namespace Inventory
{
    public interface IShop : IShopActor
    {
        int GetBuyPrice(object item);
        int GetSellPrice(object item);
        bool Buy(IShopActor costumer, object item, int amount);
        bool Sell(IShopActor costumer, object item, int amount);
        event Action OnPricesChanged;
    }
}