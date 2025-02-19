using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Slot<T> : ISlot, ISlotCallbacks
    {
        [SerializeField] private T _item;
        [SerializeField] private int _amount;
        [SerializeField] private bool _favorite;

        public event Action<object> OnItemChanged;
        public event Action<int> OnAmountChanged;
        public event Action<bool> OnFavoriteChanged;

        object ISlot.Item => Item;

        public bool IsEmpty => !Favorite && Amount == 0;

        public T Item
        {
            get => _item;
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, _item))
                    return;
                _item = value;
                OnItemChanged?.Invoke(value);
            }
        }

        public int Amount
        {
            get => _amount;
            set
            {
                if (value == _amount) return;
                _amount = value;
                OnAmountChanged?.Invoke(value);
            }
        }

        public bool Favorite
        {
            get => _favorite;
            set
            {
                if (value == _favorite) return;
                _favorite = value;
                OnFavoriteChanged?.Invoke(value);
            }
        }
    }
}