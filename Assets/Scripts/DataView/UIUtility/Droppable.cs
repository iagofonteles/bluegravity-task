using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Utility;

namespace UIUtility
{
    public class Droppable : MonoBehaviour, IDropHandler
    {
        [SerializeReference, TypeInstance] public IDroppableFilter filter = new DroppableFilters.Any();
        public UnityEvent<PointerEventData> onItemDropped;
        public UnityEvent<PointerEventData> onDragBegin;
        public UnityEvent onDragEnd;

        private void Start() => onDragEnd.Invoke();
        private void OnEnable() => Draggable.OnDragChanged += OnDragChanged;
        private void OnDisable() => Draggable.OnDragChanged -= OnDragChanged;

        private void OnDragChanged(PointerEventData e)
        {
            if (!filter.Accepts(e.pointerDrag)) return;
            if (e.dragging) onDragEnd.Invoke();
            else onDragBegin.Invoke(e);
        }

        void IDropHandler.OnDrop(PointerEventData e)
        {
            var draggable = e.pointerDrag.GetComponent<Draggable>();

            if (!filter.Accepts(e.pointerDrag))
            {
                draggable.OnEndDrag(e);
                return;
            }

            draggable.OnDrop(e);
            onItemDropped.Invoke(e);
        }
    }
}