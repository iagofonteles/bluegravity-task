using System;
using UnityEngine.Events;
using Utility;
using ViewUtility;

// ReSharper disable UnusedMember.Global

namespace Inventory.UI
{
    public class ShopController : DataView<IShop>
    {
        private static Observable<int> _amount = new(1);

        public DataView merchantView;
        public DataView costumerView;
        public DataView amountView;
        public UnityEvent<DataView> onTransactionSuceed;
        public UnityEvent<DataView> onTransactionFailed;

        public IShopActor Costumer { get; set; }

        protected override void Subscribe(IShop data)
        {
            merchantView.TrySetData(data);
            costumerView.TrySetData(Costumer);
            amountView.TrySetData(_amount);
        }

        protected override void Unsubscribe(IShop data)
        {
            merchantView.TrySetData(null);
            costumerView.TrySetData(null);
            amountView.TrySetData(null);
        }


        public void IncreaseAmount() => _amount.Value = Math.Min(_amount.Value + 1, 9);
        public void DecreaseAmount() => _amount.Value = Math.Max(_amount.Value - 1, 1);

        public void Buy(DataView view)
        {
            if (Costumer == null) throw new Exception("no Costumer set");

            var item = view.GetData();
            var count = Data.Inventory.Count(item);
            var amount = count < 0 ? _amount.Value : Math.Min(count, _amount.Value);
            var result = Data.Buy(Costumer, item, amount);

            if (result) onTransactionSuceed.Invoke(view);
            else onTransactionFailed.Invoke(view);
        }

        public void Sell(DataView view)
        {
            if (Costumer == null) throw new Exception("no Costumer set");

            var item = view.GetData();
            var count = Costumer.Inventory.Count(item);
            var amount = count < 0 ? _amount.Value : Math.Min(count, _amount.Value);
            var result = Data.Sell(Costumer, item, amount);

            if (result) onTransactionSuceed.Invoke(view);
            else onTransactionFailed.Invoke(view);
        }
    }
}