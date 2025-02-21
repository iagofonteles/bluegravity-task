using UnityEngine.Events;
using Utility;

namespace ViewUtility
{
    public abstract class ObservableViewT<T> : DataView<Observable<T>>
    {
        public UnityEvent<T> OnValueChanged;

        protected override void Subscribe(Observable<T> data)
        {
            data.OnValueChanged += UpdateValue;
            OnValueChanged.Invoke(data.Value);
        }

        protected override void Unsubscribe(Observable<T> data)
        {
            data.OnValueChanged -= UpdateValue;
        }

        private void UpdateValue(T newValue, T oldvalue)
        {
            OnValueChanged.Invoke(newValue);
        }
    }
}