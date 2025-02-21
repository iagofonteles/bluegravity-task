using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class SlotInventory<T> : IInventory<T>
    {
        [SerializeField] private Slot<T>[] _slots;
        private Func<T, int> _getMaxStack;

        private IEnumerable<Slot<T>> EmptySlots => _slots.Where(s => s.IsEmpty);
        private IEnumerable<Slot<T>> SlotsWith(T item) => _slots.Where(s => item.Equals(s.Item));

        public IReadOnlyList<Slot<T>> Slots => _slots;

        public event IInventory.ItemChangedHandler OnItemChanged;

        public SlotInventory(int size, Func<T, int> getMaxStack = null)
        {
            _slots = new Slot<T>[size];
            _getMaxStack = getMaxStack ?? (_ => int.MaxValue);

            for (int i = 0; i < size; i++)
                _slots[i] = new();
        }

        /// <summary>Prioritize already filled slots</summary>
        /// <returns>Amount of itens not added due to capacity.</returns>
        public int Add(T item, int amount)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (amount <= 0) return 0;

            var initialAmount = amount;
            var maxStack = _getMaxStack(item);

            foreach (var slot in SlotsWith(item).Concat(EmptySlots))
            {
                var maxDelta = maxStack - slot.Amount;
                var delta = Math.Min(amount, maxDelta);

                slot.Item = item;
                slot.Amount += delta;
                amount -= delta;

                if (amount == 0) break;
            }

            OnItemChanged?.Invoke(item, initialAmount - amount);
            return amount;
        }

        /// <returns>Amount of itens not removed due to shortage.</returns>
        public int Remove(T item, int amount)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (amount <= 0) return 0;

            var initialAmount = amount;

            foreach (var slot in SlotsWith(item))
            {
                var delta = Math.Min(amount, slot.Amount);
                slot.Amount -= delta;
                amount -= delta;

                if (slot.IsEmpty)
                    slot.Item = default;

                if (amount == 0) break;
            }

            OnItemChanged?.Invoke(item, amount - initialAmount);
            return amount;
        }

        public bool Fits(T item, int amount)
        {
            if (item == null) return false;
            var maxStack = _getMaxStack(item);
            var freeSlots = EmptySlots.Count() * maxStack;
            var filledSlots = SlotsWith(item).Sum(s => maxStack - s.Amount);
            return freeSlots + filledSlots >= amount;
        }

        public bool Contains(T item) => item != null && SlotsWith(item).Any(s => s.Amount > 0);
        public int Count(T item) => item == null ? 0 : SlotsWith(item).Sum(s => s.Amount);

        public IEnumerator<ISlot> GetEnumerator() => (IEnumerator<ISlot>)_slots.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _slots.GetEnumerator();
    }
}