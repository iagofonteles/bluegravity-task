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
    public class Shop<T> : IShop
    {
        public Observable<int> Money { get; }
        public IInventory Inventory { get; }

        public Observable<Func<T, int>> GetBuyPrice = new();
        public Observable<Func<T, int>> GetSellPrice = new();

        public event Action OnPricesChanged;

        int IShop.GetBuyPrice(object item) => GetBuyPrice.Value.Invoke((T)item);
        int IShop.GetSellPrice(object item) => GetSellPrice.Value.Invoke((T)item);

        public Shop(IInventory<T> inventory, int money, Func<T, int> getBuyPrice, Func<T, int> getSellPrice)
        {
            Inventory = inventory;
            Money = new(money);

            GetBuyPrice.Value = getBuyPrice ?? throw new ArgumentNullException(nameof(getBuyPrice));
            GetSellPrice.Value = getSellPrice ?? throw new ArgumentNullException(nameof(getSellPrice));

            GetBuyPrice.OnChanged += _ => OnPricesChanged?.Invoke();
            GetSellPrice.OnChanged += _ => OnPricesChanged?.Invoke();
        }

        public bool Buy(IShopActor costumer, T item, int amount) => Buy(costumer, (object)item, amount);
        public bool Sell(IShopActor costumer, T item, int amount) => Sell(costumer, (object)item, amount);

        public bool Buy(IShopActor costumer, object item, int amount)
            => Transaction(((IShop)this).GetBuyPrice, costumer, this, item, amount);

        public bool Sell(IShopActor costumer, object item, int amount)
            => Transaction(((IShop)this).GetSellPrice, this, costumer, item, amount);

        bool Transaction(Func<object, int> getPrice, IShopActor buyer, IShopActor seller, object item, int amount)
        {
            if (item == null) return false;
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