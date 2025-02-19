using System.Collections.Generic;

namespace Inventory
{
    public interface IInventory<in T> : IEnumerable<ISlot>
    {
        int Add(T item, int amount);
        int Remove(T item, int amount);
        bool Contains(T item);
        int Count(T item);
        bool Fits(T item, int amount);
    }
}