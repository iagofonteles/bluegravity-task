using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace ViewUtility
{
    public class CollectionView : DataView<IEnumerable>
    {
        [SerializeField] private DataView itemTemplate;

        List<DataView> _views = new();

        private void Start()
        {
            itemTemplate.gameObject.SetActive(false);
        }

        protected override void Subscribe(IEnumerable data)
        {
            var index = 0;
            foreach (object item in data)
                AddItem(index++, item);

            if (data is INotifyCollectionChanged notifyCollection)
                notifyCollection.CollectionChanged += CollectionChanged;
        }

        protected override void Unsubscribe(IEnumerable data)
        {
            if (data is INotifyCollectionChanged notifyCollection)
                notifyCollection.CollectionChanged -= CollectionChanged;
        }

        private void AddItem(int index, object item)
        {
            var view = Instantiate(itemTemplate, itemTemplate.transform.parent);
            view.transform.SetSiblingIndex(index + 1); // 0 is the template
            view.gameObject.SetActive(true);

            view.SetData(item);
            _views.Insert(index, view);
        }

        private void RemoveItem(int index)
        {
            Destroy(_views[index].gameObject);
            _views.RemoveAt(index);
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (var i = 0; i < e.NewItems.Count; i++)
                        AddItem(e.NewStartingIndex + i, e.NewItems[i]);
                    break;

                case NotifyCollectionChangedAction.Move:
                    Debug.LogError("Move not implemented");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (var i = 0; i < e.OldItems.Count; i++)
                        RemoveItem(e.OldStartingIndex + i);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (var i = 0; i < e.OldItems.Count; i++)
                        _views[e.OldStartingIndex + i].SetData(e.NewItems[i]);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Debug.LogError("Reset not implemented");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}