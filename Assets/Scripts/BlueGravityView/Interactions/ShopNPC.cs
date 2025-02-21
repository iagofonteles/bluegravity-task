using Inventory;
using Inventory.UI;
using UnityEngine;

namespace BlueGravity.UI
{
    public class ShopNPC : MonoBehaviour
    {
        [SerializeField] private ShopSO shopTemplate;
        [SerializeField] private ShopController shopView;

        private ShopController _shopController;
        private Shop<ItemSO> _shop;

        public void OpenShop(object interactor)
        {
            if (interactor is not Character character) return;

            _shop ??= shopTemplate.GetShop();

            if(!_shopController)
                _shopController = Instantiate(shopView);
            _shopController.Costumer = character.Player;
            _shopController.SetData(_shop);
            _shopController.gameObject.SetActive(true);
        }
    }
}