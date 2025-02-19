using ViewUtility;
using Inventory;
using UnityEngine.Events;

namespace InventoryView
{
    public class ISlotView : DataView<ISlot>
    {
        public UnityEvent<object> itemChanged;
        public UnityEvent<int> amountChanged;
        public UnityEvent<bool> favoriteChanged;

        protected override void Subscribe(ISlot data)
        {
            itemChanged.Invoke(data.Item);
            amountChanged.Invoke(data.Amount);
            favoriteChanged.Invoke(data.Favorite);

            if (data is ISlotCallbacks callbacks)
            {
                callbacks.OnItemChanged += itemChanged.Invoke;
                callbacks.OnAmountChanged += amountChanged.Invoke;
                callbacks.OnFavoriteChanged += favoriteChanged.Invoke;
            }
        }

        protected override void Unsubscribe(ISlot data)
        {
            itemChanged.Invoke(null);
            amountChanged.Invoke(0);
            favoriteChanged.Invoke(false);

            if (data is ISlotCallbacks callbacks)
            {
                callbacks.OnItemChanged -= itemChanged.Invoke;
                callbacks.OnAmountChanged -= amountChanged.Invoke;
                callbacks.OnFavoriteChanged -= favoriteChanged.Invoke;
            }
        }
    }
}