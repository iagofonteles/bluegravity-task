using UnityEngine;
using UnityEngine.Events;
using ViewUtility;

namespace Inventory.UI
{
    public class ShopPriceView : DataView<object>
    {
        [SerializeField] private ShopController controller;
        [SerializeField] private bool buyPrice = true;
        public UnityEvent<int> price;

        private void Start() => controller.Data.OnPricesChanged += UpdatePrice;
        private void OnDestroy() => controller.Data.OnPricesChanged -= UpdatePrice;
        protected override void Subscribe(object data) => UpdatePrice();
        protected override void Unsubscribe(object data) => UpdatePrice();

        private void UpdatePrice()
        {
            if (Data == null)
            {
                this.price.Invoke(0);
                return;
            }

            var price = buyPrice
                ? controller.Data.GetBuyPrice(Data)
                : controller.Data.GetSellPrice(Data);
            this.price.Invoke(price);
        }
    }
}