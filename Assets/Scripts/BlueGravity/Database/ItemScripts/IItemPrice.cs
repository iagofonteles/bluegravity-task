using UnityEngine;

// ReSharper disable UnusedType.Global

namespace BlueGravity.ItemScripts
{
    public interface IItemPrice
    {
        public int GetPrice(ItemSO item);
    }

    public class FullPrice : IItemPrice
    {
        public int GetPrice(ItemSO item) => item.Price;
    }

    public class HalfPrice : IItemPrice
    {
        public int GetPrice(ItemSO item) => item.Price / 2;
    }

    public class PriceMultiplier : IItemPrice
    {
        [SerializeField] private float multiplier = 1;
        public int GetPrice(ItemSO item) => (int)(item.Price * multiplier);
    }

    public class FullDiamondHalfOthers : IItemPrice
    {
        public int GetPrice(ItemSO item) => item.name == "Diamond" ? item.Price : item.Price / 2;
    }
}