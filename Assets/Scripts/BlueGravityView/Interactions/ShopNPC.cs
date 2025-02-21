using Inventory;
using UnityEngine;

namespace BlueGravity.UI
{
    public class ShopNPC : MonoBehaviour
    {
        [SerializeField] private ShopSO shopTemplate;
        [SerializeField] private ShopController shopView;

        private ShopController shopController;
        private Shop<ItemSO> shop;

        public void OpenShop(object interactor)
        {
            if (interactor is not Character character) return;

            shop ??= shopTemplate.GetShop();
            shop.SetCostumer(character.Inventory, character.Money);

            shopController ??= Instantiate(shopView);
            shopController.SetData(shop);
            shopController.gameObject.SetActive(true);
        }
    }
}