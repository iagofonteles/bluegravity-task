using System;
using Utility;

namespace Inventory
{
    /// <summary>
    /// Use SetMerchant and SetCostumer to begin transactions
    /// A money value less than 0 means infinite money
    /// A item amount less than 0 means infinite items
    /// Use GetBuyPrice and GetSellPrice to apply discount skills or seasonal modifiers.</summary>
    /// </summary>
    public class Shop<T>
    {
        class ShopActor
        {
            public Observable<int> money;
            public IInventory<T> inventory;
        }

        private ShopActor merchant = new();
        private ShopActor costumer = new();

        public Observable<Func<T, int>> GetBuyPrice = new();
        public Observable<Func<T, int>> GetSellPrice = new();

        public Shop(Func<T, int> getBuyPrice, Func<T, int> getSellPrice)
        {
            GetBuyPrice.Value = getBuyPrice ?? throw new ArgumentNullException(nameof(getBuyPrice));
            GetSellPrice.Value = getSellPrice ?? throw new ArgumentNullException(nameof(getSellPrice));
        }

        public void SetMerchant(IInventory<T> inventory, Observable<int> money)
        {
            merchant.inventory = inventory;
            merchant.money = money;
        }

        public void SetCostumer(IInventory<T> inventory, Observable<int> money)
        {
            costumer.inventory = inventory;
            costumer.money = money;
        }

        public bool Buy(T item, int amount) => BuyFrom(GetBuyPrice.Value, costumer, merchant, item, amount);
        public bool Sell(T item, int amount) => BuyFrom(GetSellPrice.Value, merchant, costumer, item, amount);

        bool BuyFrom(Func<T, int> getPrice, ShopActor buyer, ShopActor seller, T item, int amount)
        {
            var price = getPrice(item) * amount;
            var availableMoney = buyer.money.Value;
            var availableItems = seller.inventory.Count(item);

            if (availableMoney >= 0 && availableMoney < price) return false;
            if (availableItems >= 0 && availableItems < amount) return false;
            if (!buyer.inventory.Fits(item, amount)) return false;

            seller.money.Value += price;
            buyer.money.Value -= price;
            seller.inventory.Remove(item, amount);
            buyer.inventory.Add(item, amount);

            return true;
        }
    }
}