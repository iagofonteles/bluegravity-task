using Inventory;
using UnityEngine.Events;
using ViewUtility;

namespace BlueGravity.UI
{
    public abstract class ShopController<T> : DataView<Shop<T>>
    {
        public int buyAmount = 1;

        public UnityEvent<DataView> OnTransactionSuceed;
        public UnityEvent<DataView> OnTransactionFailed;

        protected override void Subscribe(Shop<T> data) { }
        protected override void Unsubscribe(Shop<T> data) { }

        public void Buy(DataView view)
        {
            var item = view.GetData<T>();
            var result = Data.Buy(item, buyAmount);

            if (result) OnTransactionSuceed.Invoke(view);
            else OnTransactionFailed.Invoke(view);
        }

        public void Sell(DataView view)
        {
            var item = view.GetData<T>();
            var result = Data.Sell(item, buyAmount);

            if (result) OnTransactionSuceed.Invoke(view);
            else OnTransactionFailed.Invoke(view);
        }
    }
}