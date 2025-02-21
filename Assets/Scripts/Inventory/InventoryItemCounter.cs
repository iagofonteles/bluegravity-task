using System;

namespace Inventory
{
    /// <summary>
    /// Tracks the total count of an item type in the inventory 
    /// </summary>
    public class InventoryItemCounter : ISlot, ISlotCallbacks
    {
        IInventory _inventory;
        object _item;
        int _amount;
        
        public InventoryItemCounter(IInventory inventory)
        {
            _inventory = inventory;
        }

        public IInventory Inventory
        {
            get => _inventory;
            set
            {
                if (_inventory != null)
                    _inventory.OnItemChanged -= OnInventoryChanged;

                _inventory = value;

                if (_inventory != null)
                    _inventory.OnItemChanged += OnInventoryChanged;

                _amount = _inventory?.Count(Item) ?? 0;
                OnAmountChanged?.Invoke(_amount);
            }
        }

        public object Item
        {
            get => _item;
            set
            {
                _item = value;
                OnItemChanged?.Invoke(value);

                _amount = _inventory?.Count(Item) ?? 0;
                OnAmountChanged?.Invoke(_amount);
            }
        }

        public int Amount
        {
            get => _amount;
            set => throw new InvalidOperationException();
        }

        public bool Favorite
        {
            get => false;
            set => throw new InvalidOperationException();
        }

        public bool IsEmpty { get; }
        public event Action<object> OnItemChanged;
        public event Action<int> OnAmountChanged;
        public event Action<bool> OnFavoriteChanged;

        private void OnInventoryChanged(object item, int amount)
        {
            if (item != _item) return;
            _amount += amount;
            OnAmountChanged?.Invoke(_amount);
        }
    }
}