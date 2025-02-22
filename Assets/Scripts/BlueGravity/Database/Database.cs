using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace BlueGravity
{
    public class Database
    {
        Dictionary<Type, object> _fetched = new();

        public T Get<T>(string name) where T : UnityEngine.Object
            => string.IsNullOrEmpty(name) ? null : GetAll<T>().GetValueOrDefault(name);

        public IReadOnlyDictionary<string, T> GetAll<T>() where T : UnityEngine.Object
        {
            var type = typeof(T);
            if (!_fetched.ContainsKey(type))
                _fetched[type] = FetchAddressables<T>();

            return (IReadOnlyDictionary<string, T>)_fetched[type];
        }

        Dictionary<string, T> FetchAddressables<T>() where T : UnityEngine.Object
        {
            var key = typeof(T).Name;
            var result = new Dictionary<string, T>();
            var operation = Addressables.LoadAssetsAsync<T>(key, Callback);
            operation.WaitForCompletion();

            return result;
            void Callback(T item) => result[item.name] = item;
        }
    }
}