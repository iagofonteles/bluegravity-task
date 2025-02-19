using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Utility;

namespace Inventory
{
    [Serializable]
    public class ListInventory<T> : IInventory<T>, INotifyCollectionChanged
    {
        private ObservableList<Slot<T>> _slots = new();
        private Func<T, int> _getMaxStack = _ => int.MaxValue;

        private Slot<T> SlotWith(T item) => _slots.FirstOrDefault(s => item.Equals(s.Item));

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => _slots.CollectionChanged += value;
            remove => _slots.CollectionChanged -= value;
        }

        public ListInventory() { }

        public ListInventory(Func<T, int> getMaxStack = null, IEnumerable<Slot<T>> items = null)
        {
            _getMaxStack = getMaxStack ?? _getMaxStack;
            
            if (items != null)
                foreach (var slot in items)
                    _slots.Add(slot);
        }

        /// <summary>Prioritize already filled slots</summary>
        /// <returns>Amount of itens not added due to capacity.</returns>
        public int Add(T item, int amount)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (amount == 0) return 0;
            if (amount < 0) return Remove(item, -amount);

            var slot = SlotWith(item);

            if (slot == null)
            {
                slot = new();
                slot.Item = item;
                _slots.Add(slot);
            }

            var maxDelta = _getMaxStack(item) - slot.Amount;
            var delta = Math.Min(amount, maxDelta);

            slot.Amount += delta;
            amount -= delta;

            return amount;
        }

        /// <returns>Amount of itens not removed due to shortage.</returns>
        public int Remove(T item, int amount)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (amount == 0) return 0;
            if (amount < 0) return Remove(item, -amount);

            var slot = SlotWith(item);
            if (slot == null) return amount;

            var delta = Math.Min(amount, slot.Amount);
            slot.Amount -= delta;
            amount -= delta;

            if (slot.IsEmpty)
                _slots.Remove(slot);

            return amount;
        }

        public bool Fits(T item, int amount)
        {
            var slot = SlotWith(item);
            var maxStack = _getMaxStack(item);
            return slot == null || maxStack - slot.Amount >= amount;
        }

        public bool Contains(T item) => SlotWith(item) != null;
        public int Count(T item) => SlotWith(item)?.Amount ?? 0;

        public IEnumerator<ISlot> GetEnumerator() => _slots.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _slots.GetEnumerator();
    }
}