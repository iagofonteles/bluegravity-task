using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlueGravity.ItemScripts
{
    // ReSharper disable once UnusedType.Global
    public class LootBox : IUsabeItem
    {
        [SerializeField] private List<ItemSO> contents;

        public bool ConsumeOnUse => true;

        public bool TryUse(object context)
        {
            if (context is not Player player)
                return false;

            var amount = Random.Range(1, 4);
            var index = Random.Range(0, contents.Count);
            var item = contents[index];
            var bag = player.Inventory;

            if (!bag.Fits(item, amount)) return false;
            bag.Add(item, amount);
            return true;
        }
    }

    // ReSharper disable once UnusedType.Global
}