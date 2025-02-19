using UnityEngine;
using UnityEngine.EventSystems;

namespace UIUtility
{
    public class RectTransformDragger : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        public RectTransform target;
        [Min(-1)] public Vector2 border;

        private Vector2 _min, _max;

        public void OnBeginDrag(PointerEventData eventData)
        {
            var canvas = target.GetComponentInParent<Canvas>();
            _min = border + target.sizeDelta * target.pivot;
            _max = new Vector2(Screen.width, Screen.height) * canvas.scaleFactor; // TODO test with canvas scale
            _max -= border + target.sizeDelta * (Vector2.one - target.pivot);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var pos = target.position;
            pos.x = Mathf.Clamp(pos.x + eventData.delta.x, _min.x, _max.x);
            pos.y = Mathf.Clamp(pos.y + eventData.delta.y, _min.y, _max.y);
            target.position = pos;
        }
    }
}