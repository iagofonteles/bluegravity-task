using System.Collections;
using UnityEngine;

namespace ViewUtility
{
    public class FixedCollectionView : DataView<IEnumerable>
    {
        [SerializeField] private DataView[] itemViews;

        protected override void Subscribe(IEnumerable data)
        {
            var i = 0;
            foreach (var item in data)
                itemViews[i++].SetData(item);
        }

        protected override void Unsubscribe(IEnumerable data)
        {
            foreach (var view in itemViews)
                view.SetData(null);
        }
    }
}