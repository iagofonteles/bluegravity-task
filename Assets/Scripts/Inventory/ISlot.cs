using System;

namespace Inventory
{
    public interface ISlot
    {
        object Item { get; }
        int Amount { get; }
        bool Favorite { get; }
    }

    public interface ISlotCallbacks
    {
        event Action<object> OnItemChanged;
        event Action<int> OnAmountChanged;
        event Action<bool> OnFavoriteChanged;
    }
}