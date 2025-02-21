using Utility;

namespace Inventory
{
    public interface IShopActor
    {
        public Observable<int> Money { get; }
        public IInventory Inventory { get; }
    }
}