using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIUtility
{
    public class RectTransformResizer : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        public RectTransform target;
        [Min(0)] public Vector2 minSize;
        [Min(0)] public Vector2 snap;

        private Vector2 _startPosition;
        private Vector2 _startSize;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
            _startSize = target.sizeDelta;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var delta = eventData.position - _startPosition;
            delta.y = -delta.y;
            var size = _startSize + delta;

            if (snap.x > 0) delta.x -= delta.x % snap.x;
            if (snap.y > 0) delta.y -= delta.y % snap.y;

            size.x = Math.Max(minSize.x, _startSize.x + delta.x);
            size.y = Math.Max(minSize.y, _startSize.y + delta.y);

            target.sizeDelta = size;
        }
    }
}