using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Slot<T> : ISlot, ISlotCallbacks
    {
        [SerializeField] private T item;
        [SerializeField] private int amount;
        [SerializeField] private bool favorite;

        public event Action<object> OnItemChanged;
        public event Action<int> OnAmountChanged;
        public event Action<bool> OnFavoriteChanged;

        object ISlot.Item
        {
            get => Item;
            set => Item = value is T v ? v : default;
        }

        public bool IsEmpty => !Favorite && Amount == 0;

        public T Item
        {
            get => item;
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, item))
                    return;
                item = value;
                OnItemChanged?.Invoke(value);
            }
        }

        public int Amount
        {
            get => amount;
            set
            {
                if (value == amount) return;
                amount = value;
                OnAmountChanged?.Invoke(value);
            }
        }

        public bool Favorite
        {
            get => favorite;
            set
            {
                if (value == favorite) return;
                favorite = value;
                OnFavoriteChanged?.Invoke(value);
            }
        }
    }
}