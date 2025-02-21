using System;

namespace Inventory
{
    public interface ISlot
    {
        object Item { get; set; }
        int Amount { get; set;}
        bool Favorite { get; set;}
        bool IsEmpty { get; }
    }

    public interface ISlotCallbacks
    {
        event Action<object> OnItemChanged;
        event Action<int> OnAmountChanged;
        event Action<bool> OnFavoriteChanged;
    }
}