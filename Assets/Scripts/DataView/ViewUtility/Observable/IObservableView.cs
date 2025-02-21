using UnityEngine.Events;
using Utility;

namespace ViewUtility
{
    public class IObservableView : DataView<IObservable>
    {
        public UnityEvent<object> onValueChanged;

        protected override void Subscribe(IObservable data)
        {
            data.OnChanged += onValueChanged.Invoke;
            onValueChanged.Invoke(data.Value);
        }

        protected override void Unsubscribe(IObservable data)
        {
            data.OnChanged -= onValueChanged.Invoke;
        }
    }
}