using System;
using Inventory.Internal;
using Utility;

namespace Inventory
{
    /// <summary>
    /// Use SetMerchant and SetCostumer to begin transactions
    /// A money value less than 0 means infinite money
    /// A item amount less than 0 means infinite items
    /// Use GetBuyPrice and GetSellPrice to apply discount skills or seasonal modifiers.</summary>
    /// </summary>
    public class Shop<T> : IShop
    {
        IShopActor IShop.Merchant => Merchant;
        IShopActor IShop.Costumer => Costumer;

        public ShopActor<T> Merchant { get; } = new();
        public ShopActor<T> Costumer { get; } = new();

        public Observable<Func<T, int>> GetBuyPrice = new();
        public Observable<Func<T, int>> GetSellPrice = new();

        public Shop(Func<T, int> getBuyPrice, Func<T, int> getSellPrice)
        {
            GetBuyPrice.Value = getBuyPrice ?? throw new ArgumentNullException(nameof(getBuyPrice));
            GetSellPrice.Value = getSellPrice ?? throw new ArgumentNullException(nameof(getSellPrice));
        }

        public void SetMerchant(IInventory<T> inventory, Observable<int> money)
        {
            Merchant.Inventory = inventory;
            Merchant.Money = money;
        }

        public void SetCostumer(IInventory<T> inventory, Observable<int> money)
        {
            Costumer.Inventory = inventory;
            Costumer.Money = money;
        }

        public bool Buy(T item, int amount) => BuyFrom(GetBuyPrice.Value, Costumer, Merchant, item, amount);
        public bool Sell(T item, int amount) => BuyFrom(GetSellPrice.Value, Merchant, Costumer, item, amount);

        bool BuyFrom(Func<T, int> getPrice, ShopActor<T> buyer, ShopActor<T> seller, T item, int amount)
        {
            var price = getPrice(item) * amount;
            var availableMoney = buyer.Money.Value;
            var availableItems = seller.Inventory.Count(item);

            if (availableMoney >= 0 && availableMoney < price) return false;
            if (availableItems >= 0 && availableItems < amount) return false;
            if (!buyer.Inventory.Fits(item, amount)) return false;

            seller.Money.Value += price;
            buyer.Money.Value -= price;
            seller.Inventory.Remove(item, amount);
            buyer.Inventory.Add(item, amount);

            return true;
        }
    }
}