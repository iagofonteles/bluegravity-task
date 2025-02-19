using UnityEngine;

namespace BlueGravity.ItemScripts
{
    public class Potion : IUsabeItem
    {
        [SerializeField] private int healthAmount;
        [SerializeField] private int manaAmount;

        public bool ConsumeOnUse => true;

        public bool TryUse(object context)
        {
            var player = Game.Save.Get<PlayerStats>();
            player.Health.Value += healthAmount;
            player.Mana.Value += manaAmount;
            return true;
        }
    }
}