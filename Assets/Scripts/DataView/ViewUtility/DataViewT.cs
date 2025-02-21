using System.Collections.Generic;
using UnityEngine.Events;

namespace ViewUtility
{
    public abstract class DataView<T> : DataView
    {
        private T _data;

        public UnityEvent<object> OnDataChanged;

        public T Data
        {
            get => _data;
            set
            {
                if (EqualityComparer<T>.Default.Equals(_data, value))
                    return;

                if (_data != null) Unsubscribe(_data);
                _data = value;
                if (_data != null) Subscribe(_data);
                OnDataChanged.Invoke(value);
            }
        }

        public override object GetData() => Data;
        public override void SetData(object data) => Data = data is T d ? d : default;

        protected abstract void Subscribe(T data);
        protected abstract void Unsubscribe(T data);

        private void OnDestroy()
        {
            if (Data != null)
                Unsubscribe(Data);
        }
    }
}