using UnityEngine;
using ViewUtility;

namespace BlueGravity.UI
{
    public class CharacterStatsView : DataView<CharacterStats>
    {
        [SerializeField] private DataView healthView;
        [SerializeField] private DataView manaView;
        [SerializeField] private DataView moveSpeedView;

        protected override void Subscribe(CharacterStats data)
        {
            healthView.TrySetData(data.Health);
            manaView.TrySetData(data.Mana);
            moveSpeedView.TrySetData(data.MoveSpeed);
        }

        protected override void Unsubscribe(CharacterStats data)
        {
            healthView.TrySetData(null);
            manaView.TrySetData(null);
            moveSpeedView.TrySetData(null);
        }
    }
}