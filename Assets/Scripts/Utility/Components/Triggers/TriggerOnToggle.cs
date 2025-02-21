using UnityEngine;
using UnityEngine.Events;

namespace Utility.Triggers
{
    public class TriggerOnToggle : MonoBehaviour
    {
        [SerializeField] private bool value;
        public UnityEvent<bool> onValueChanged;
        public UnityEvent<bool> onValueInverse;

        [ContextMenu("Toggle")]
        public void Toggle() => Value = !Value;
        private void Start() => Value = value;

        public bool Value
        {
            get => value;
            set
            {
                this.value = value;
                onValueChanged?.Invoke(value);
                onValueInverse?.Invoke(!value);
            }
        }
    }
}