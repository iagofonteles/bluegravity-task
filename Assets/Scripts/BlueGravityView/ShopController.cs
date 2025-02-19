using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.Events;
using Utility;
using ViewUtility;

namespace BlueGravity.UI
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private List<Slot<Item>> items;

        public Shop<Item> shop = new(i => i.Price, i => i.Price / 2);
        public int buyAmount = 1;

        public UnityEvent<DataView> OnTransactionSuceed;
        public UnityEvent<DataView> OnTransactionFailed;

        private void Awake()
        {
            var playerInventory = Game.Save.Get<ItemBag>();
            var playerMoney = Game.Save.Get<MoneyBag>();
            var shopInventory = new ListInventory<Item>(null, items);
            var shopMoney = new Observable<int>(-1);

            shop.SetMerchant(shopInventory, shopMoney);
            shop.SetCostumer(playerInventory, playerMoney);
        }

        public void Buy(DataView view)
        {
            var item = view.GetData<Item>();
            var result = shop.Buy(item, buyAmount);

            if (result) OnTransactionSuceed.Invoke(view);
            else OnTransactionFailed.Invoke(view);
        }

        public void Sell(DataView view)
        {
            var item = view.GetData<Item>();
            var result = shop.Sell(item, buyAmount);

            if (result) OnTransactionSuceed.Invoke(view);
            else OnTransactionFailed.Invoke(view);
        }
    }
}