using UnityEngine;
using UnityEngine.Events;
using ViewUtility;
using DataView = ViewUtility.DataView;

namespace BlueGravity.UI
{
    public class PlayerView : DataView<Player>
    {
        public DataView inventoryView;
        public DataView moneyView;
        public DataView statsView;
        public DataView hotbarView;
        public DataView equipmentsView;

        public UnityEvent<string> displayName;
        public UnityEvent<Vector3> position;

        protected override void Subscribe(Player data)
        {
            inventoryView.TrySetData(data.Inventory);
            moneyView.TrySetData(data.Money);
            statsView.TrySetData(data.Stats);
            hotbarView.TrySetData(data.Hotbar);
            equipmentsView.TrySetData(data.Equipments);

            displayName.Invoke(data.DisplayName);
            position.Invoke(data.Position);
        }

        protected override void Unsubscribe(Player data)
        {
            inventoryView.TrySetData(null);
            moneyView.TrySetData(null);
            statsView.TrySetData(null);
            hotbarView.TrySetData(null);
            equipmentsView.TrySetData(null);

            displayName.Invoke(null);
        }
    }
}