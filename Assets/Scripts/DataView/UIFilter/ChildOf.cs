using UnityEngine;

namespace UIUtility.DroppableFilters
{
    public class ChildOf : IDroppableFilter
    {
        public Transform Parent;
        public bool Accepts(GameObject gameObject) => gameObject.transform.IsChildOf(Parent);
    }
}