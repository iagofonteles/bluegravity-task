namespace BlueGravity.UI
{
    public class ShopController : ShopController<ItemSO>
    {
        public void RefreshShop(ShopSO shopSo) => SetData(shopSo.GetShop());
    }
}