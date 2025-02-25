using UnityEngine;
using UnityEngine.EventSystems;

namespace UIUtility
{
    public class RectTransformDragger : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        public RectTransform target;
        public Vector2 border;

        private Vector2 _min, _max;

        public void OnBeginDrag(PointerEventData eventData)
        {
            var scale = target.GetComponentInParent<Canvas>().scaleFactor;
            var pivot = new Vector2(target.pivot.x, target.pivot.y);
            var minSize = target.sizeDelta * pivot;
            var maxSize = target.sizeDelta * (Vector2.one - pivot);

            _min = new(0, -Screen.height / scale);
            _min += border + minSize;
            
            _max = new Vector2(Screen.width / scale, 0);
            _max -= border + maxSize;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var pos = target.anchoredPosition;
            pos.x = Mathf.Clamp(pos.x + eventData.delta.x, _min.x, _max.x);
            pos.y = Mathf.Clamp(pos.y + eventData.delta.y, _min.y, _max.y);
            target.anchoredPosition = pos;
        }
    }
}