using System;
using UnityEngine.Events;
using ViewUtility;
// ReSharper disable UnusedMember.Global

namespace Inventory.UI
{
    public class ShopController : DataView<IShop>
    {
        private static int _amount = 1;
        
        public DataView merchantView;
        public DataView costumerView;
        public UnityEvent<DataView> onTransactionSuceed;
        public UnityEvent<DataView> onTransactionFailed;

        public IShopActor Costumer { get; set; }

        protected override void Subscribe(IShop data)
        {
            merchantView.TrySetData(data);
            costumerView.TrySetData(Costumer);
        }

        protected override void Unsubscribe(IShop data)
        {
            merchantView.TrySetData(null);
            costumerView.TrySetData(null);
        }

        public void IncreaseAmount() => _amount = Math.Min(_amount + 1, 10);
        public void DecreaseAmount() => _amount = Math.Max(_amount - 1, 1);

        public void Buy(DataView view)
        {
            if (Costumer == null) throw new Exception("no Costumer set");

            var item = view.GetData();
            var result = Data.Buy(Costumer, item, _amount);

            if (result) onTransactionSuceed.Invoke(view);
            else onTransactionFailed.Invoke(view);
        }

        public void Sell(DataView view)
        {
            if (Costumer == null) throw new Exception("no Costumer set");

            var item = view.GetData();
            var result = Data.Sell(Costumer, item, _amount);

            if (result) onTransactionSuceed.Invoke(view);
            else onTransactionFailed.Invoke(view);
        }
    }
}