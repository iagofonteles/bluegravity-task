using UnityEngine;
using Utility;

namespace BlueGravity
{
    public class CharacterStatsSave : IJsonGameSave
    {
        [SerializeField] private int health;
        [SerializeField] private int mana;

        public void WriteTo(CharacterStats stats)
        {
            stats.Health.Value = health;
            stats.Mana.Value = mana;
        }

        public void ReadFrom(CharacterStats stats)
        {
            health = stats.Health.Value;
            mana = stats.Mana.Value;
        }
    }
}