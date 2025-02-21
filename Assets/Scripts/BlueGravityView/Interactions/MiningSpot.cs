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
                character.Inventory.Add(item, 1);
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