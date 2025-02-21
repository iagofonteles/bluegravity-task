using BlueGravity.CharacterStates;
using UnityEngine;

namespace BlueGravity.UI
{
    public class MiningSpot : MonoBehaviour
    {
        public ItemSO item;
        public AudioSource getItemSfx;

        public void StartMining(object interactor)
        {
            if (interactor is not Character character) return;
            
            void GetItem()
            {
                var amount = character.Player.Stats.MiningPower.Value;
                character.Player.Inventory.Add(item, amount);
                if(getItemSfx) getItemSfx.Play();
            }

            var args = new DynamicStateArgs
            {
                animation = "Mine",
                trigger = GetItem,
            };

            character.StateMachine.SetState<DynamicState>(args);
        }
    }
}