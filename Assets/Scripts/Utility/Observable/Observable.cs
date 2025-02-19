using System;
using System.Collections.Generic;

namespace Utility
{
    public delegate void ValueChangedHandler<in T>(T newValue, T oldValue);

    public class IObservable<T>
    {
        event ValueChangedHandler<T> OnValueChanged;
    }

    [Serializable]
    public class Observable<T> : IObservable<T>
    {
        private T _value;

        public Observable() { }

        public Observable(T value) => _value = value;

        public T Value
        {
            get => _value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, _value))
                    return;

                var old = _value;
                _value = value;
                OnValueChanged?.Invoke(value, old);
            }
        }

        public event ValueChangedHandler<T> OnValueChanged;
    }
}