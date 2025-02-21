using UnityEngine;

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
}