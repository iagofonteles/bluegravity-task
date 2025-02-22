using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIUtility
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public delegate void DragChangedHandler(PointerEventData e);
    
        public static event DragChangedHandler OnDragChanged;

        public GameObject target;
        public bool returnToOrigin = true;
        public UnityEvent<PointerEventData> onDragBegin;
        public UnityEvent<PointerEventData> onDragEnd;
        public UnityEvent<PointerEventData> onDrop;

        private Vector2 _origin;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            _origin = target.transform.position;

            // put image in front
            foreach (var grapchic in target.GetComponentsInChildren<MaskableGraphic>())
                grapchic.maskable = false;
            foreach (var canvas in target.GetComponentsInChildren<Canvas>())
                canvas.overrideSorting = true;

            OnDragChanged?.Invoke(eventData);
            onDragBegin.Invoke(eventData);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            target.transform.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (returnToOrigin) target.transform.position = _origin;

            // put image back
            foreach (var grapchic in target.GetComponentsInChildren<MaskableGraphic>())
                grapchic.maskable = true;
            foreach (var canvas in target.GetComponentsInChildren<Canvas>())
                canvas.overrideSorting = false;

            OnDragChanged?.Invoke(eventData);
            onDragEnd.Invoke(eventData);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (returnToOrigin) target.transform.position = _origin;
            OnDragChanged?.Invoke(eventData);
            onDrop.Invoke(eventData);
        }

    }
}