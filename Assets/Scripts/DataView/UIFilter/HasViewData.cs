using System;
using UnityEngine;
using ViewUtility;

namespace UIUtility.DroppableFilters
{
    public class HasViewData : IDroppableFilter
    {
        public string typeFullName;

        public bool Accepts(GameObject gameObject)
        {
            var data = gameObject.GetComponent<DataView>()?.GetData();
            var type = Type.GetType(typeFullName);
            return type.IsAssignableFrom(data?.GetType());
        }
    }
}