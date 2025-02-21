using System.Collections.Generic;

namespace Inventory
{
    public interface IInventory : IEnumerable<ISlot>
    {
        public delegate void ItemChangedHandler(object item, int amount);

        int Add(object item, int amount);
        int Remove(object item, int amount);
        bool Contains(object item);
        int Count(object item);
        bool Fits(object item, int amount);
        event ItemChangedHandler OnItemChanged;
    }

    public interface IInventory<in T> : IInventory
    {
        int Add(T item, int amount);
        int Remove(T item, int amount);
        bool Contains(T item);
        int Count(T item);
        bool Fits(T item, int amount);

        int IInventory.Add(object item, int amount) => Add((T)item, amount);
        int IInventory.Remove(object item, int amount) => Remove((T)item, amount);
        bool IInventory.Contains(object item) => Contains((T)item);
        int IInventory.Count(object item) => Count((T)item);
        bool IInventory.Fits(object item, int amount) => Fits((T)item, amount);
    }
}