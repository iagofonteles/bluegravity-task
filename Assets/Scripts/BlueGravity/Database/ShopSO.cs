using System.Collections.Generic;
using BlueGravity.Database.ItemScripts;
using Inventory;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [CreateAssetMenu(menuName = "Game/Shop")]
    public class ShopSO : ScriptableObject
    {
        [SerializeField] private int merchantMoney = -1;
        [SerializeReference, TypeInstance] private IItemPrice buyPrice = new FullPrice();
        [SerializeReference, TypeInstance] private IItemPrice sellPrice = new HalfPrice();
        [SerializeField] private List<Slot<ItemSO>> items;

        public Shop<ItemSO> GetShop()
        {
            var inventory = new ListInventory<ItemSO>(null, items);

            var shop = new Shop<ItemSO>(inventory, merchantMoney,
                buyPrice.GetPrice, sellPrice.GetPrice);

            return shop;
        }
    }
}