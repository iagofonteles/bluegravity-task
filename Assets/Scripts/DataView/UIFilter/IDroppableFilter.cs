using UnityEngine;

namespace UIUtility
{
    public interface IDroppableFilter
    {
        bool Accepts(GameObject gameObject);
    }
}