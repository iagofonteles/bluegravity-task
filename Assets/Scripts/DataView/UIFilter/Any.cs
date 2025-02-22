using UnityEngine;

namespace UIUtility.DroppableFilters
{
    public class Any : IDroppableFilter
    {
        public bool Accepts(GameObject _) => true;
    }
}