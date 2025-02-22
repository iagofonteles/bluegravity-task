using UnityEngine;
using UnityEngine.Events;
using ViewUtility;

namespace BlueGravity
{
    public class ItemView : DataView<ItemSO>
    {
        public UnityEvent<string> displayName;
        public UnityEvent<Sprite> icon;
        public UnityEvent<string> description;
        public UnityEvent<int> price;

        protected override void Subscribe(ItemSO data)
        {
            displayName.Invoke(data.DisplayName);
            icon.Invoke(data.Icon);
            description.Invoke(data.Description);
            price.Invoke(data.Price);
        }

        protected override void Unsubscribe(ItemSO data)
        {
            displayName.Invoke("");
            icon.Invoke(null);
            description.Invoke("");
            price.Invoke(0);
        }
    }
}