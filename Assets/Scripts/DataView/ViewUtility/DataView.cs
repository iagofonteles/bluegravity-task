using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ViewUtility
{
    public abstract class DataView : MonoBehaviour, IDataView
    {
        public abstract object GetData();
        public abstract void SetData(object data);

        public T GetData<T>(bool allowNull = false)
        {
            if (allowNull && GetData() is null) return default;
            if (GetData() is not T data) throw new DataTypeExeption<T>(GetData());
            return data;
        }
    }

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