using BlueGravity.CharacterStates;
using UnityEngine;

namespace BlueGravity.UI
{
    public class DynamicCharacterAction : MonoBehaviour
    {
        public DynamicStateArgs stateArgs;

        public void EnterState(object context)
        {
            if (context is not Character character) return;
            character.StateMachine.SetState<DynamicState>(stateArgs);
        }
    }
}