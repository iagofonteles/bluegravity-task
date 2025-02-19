using System.Collections;
using Utility;

namespace Inventory.Internal
{
    public interface IShop
    {
        public IShopActor Merchant { get; }
        public IShopActor Costumer { get; }
    }
    
    public interface IShopActor
    {
        public Observable<int> Money { get;  }
        public IEnumerable Inventory { get;  }
    }
}