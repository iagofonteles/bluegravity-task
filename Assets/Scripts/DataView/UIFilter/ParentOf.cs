using UnityEngine;

namespace UIUtility.DroppableFilters
{
    public class ParentOf : IDroppableFilter
    {
        public Transform Parent;
        public bool Accepts(GameObject gameObject) => Parent.IsChildOf(gameObject.transform);
    }
}