using System.Collections.Generic;
using Inventory;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [CreateAssetMenu(menuName = "Game/Shop")]
    public class ShopSO : ScriptableObject
    {
        [SerializeField] private int merchantMoney = -1;
        [SerializeField] private List<Slot<ItemSO>> items;

        public Shop<ItemSO> GetShop()
        {
            var shop = new Shop<ItemSO>(i => i.Price, i => i.Price / 2);
            var playerInventory = Game.Save.Get<ItemBag>();
            var playerMoney = Game.Save.Get<MoneyBag>();
            var shopInventory = new ListInventory<ItemSO>(null, items);
            var shopMoney = new Observable<int>(merchantMoney);

            shop.SetMerchant(shopInventory, shopMoney);
            shop.SetCostumer(playerInventory, playerMoney);
            return shop;
        }
    }
}