using System.Collections;
using Inventory.Internal;
using Utility;

namespace Inventory
{
    public class ShopActor<T> : IShopActor
    {
        public Observable<int> Money { get; internal set; }
        public IInventory<T> Inventory { get; internal set; }

        IEnumerable IShopActor.Inventory => Inventory;
    }
}