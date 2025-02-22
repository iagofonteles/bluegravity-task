using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace ViewUtility
{
    public abstract class DataView : MonoBehaviour, IDataView
    {
        public UnityEvent<object> onDataChanged;
        
        public abstract object GetData();
        public abstract void SetData(object data);
        public void CopyData(DataView view) => SetData(view.GetData());
        public void ResetData() => SetData(null);
        public void DestroyTarget(Object target) => Destroy(target);

        public void RefreshData()
        {
            var data = GetData(); 
            SetData(null);
            SetData(data);
        }

        public T GetData<T>(bool allowNull = false)
        {
            if (allowNull && GetData() is null) return default;
            if (GetData() is not T data) throw new DataTypeExeption<T>(GetData());
            return data;
        }

        public void SetDataFromDrag(PointerEventData e)
        {
            var view = e.pointerDrag.GetComponent<DataView>();
            SetData(view?.GetData());
        }
    }

    public static class DataViewExtensions
    {
        /// <summary>Use this for optional views in inspector</summary>
        public static object TryGetData(this DataView view, object data)
        {
            return view ? view.GetData() : null;
        }

        /// <summary>Use this for optional views in inspector</summary>
        public static void TrySetData(this DataView view, object data)
        {
            if (view) view.SetData(data);
        }
    }
}