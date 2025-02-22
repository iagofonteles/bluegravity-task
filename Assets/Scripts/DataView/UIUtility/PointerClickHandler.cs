using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UIUtility
{
    public class PointerClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent<PointerEventData> onLeftClick;
        public UnityEvent<PointerEventData> onRightClick;
        public UnityEvent<PointerEventData> onMiddleClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            (eventData.button switch
            {
                PointerEventData.InputButton.Left => onLeftClick,
                PointerEventData.InputButton.Right => onRightClick,
                PointerEventData.InputButton.Middle => onMiddleClick,
            }).Invoke(eventData);
        }
    }
}