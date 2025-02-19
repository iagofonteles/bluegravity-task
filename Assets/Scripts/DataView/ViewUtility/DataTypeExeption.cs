using System;

namespace ViewUtility
{
    public class DataTypeExeption<T> : Exception
    {
        public DataTypeExeption(object obj)
            : base($"Expected {typeof(T).Name} but received {obj?.GetType().Name}") { }
    }
}