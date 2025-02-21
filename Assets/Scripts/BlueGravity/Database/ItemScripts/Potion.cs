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
            if (context is not Character character) 
                return false;
            
            character.Stats.Health.Value += healthAmount;
            character.Stats.Mana.Value += manaAmount;
            return true;
        }
    }
}