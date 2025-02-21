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
            if (context is not Player player) 
                return false;
            
            player.Stats.Health.Value += healthAmount;
            player.Stats.Mana.Value += manaAmount;
            return true;
        }
    }
}