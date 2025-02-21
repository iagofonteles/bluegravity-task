using ViewUtility;
using UnityEngine.Events;

namespace Inventory.UI
{
    public class SlotView : DataView<ISlot>
    {
        public UnityEvent<object> item;
        public UnityEvent<int> amount;
        public UnityEvent<bool> favorite;
        public UnityEvent<bool> notEmpty;

        protected override void Subscribe(ISlot data)
        {
            item.Invoke(data.Item);
            amount.Invoke(data.Amount);
            favorite.Invoke(data.Favorite);
            notEmpty.Invoke(!data.IsEmpty);

            if (data is ISlotCallbacks callbacks)
            {
                callbacks.OnItemChanged += item.Invoke;
                callbacks.OnAmountChanged += OnAmountChanged;
                callbacks.OnFavoriteChanged += OnFavoriteChanged;
            }
        }

        protected override void Unsubscribe(ISlot data)
        {
            item.Invoke(null);
            amount.Invoke(0);
            favorite.Invoke(false);
            notEmpty.Invoke(false);

            if (data is ISlotCallbacks callbacks)
            {
                callbacks.OnItemChanged -= item.Invoke;
                callbacks.OnAmountChanged -= amount.Invoke;
                callbacks.OnFavoriteChanged -= favorite.Invoke;
            }
        }

        private void OnItemChanged(object value)
        {
            item.Invoke(value);
            notEmpty.Invoke(!Data.IsEmpty);
        }

        private void OnAmountChanged(int value)
        {
            amount.Invoke(value);
            notEmpty.Invoke(!Data.IsEmpty);
        }

        private void OnFavoriteChanged(bool value)
        {
            favorite.Invoke(value);
            notEmpty.Invoke(!Data.IsEmpty);
        }
    }
}