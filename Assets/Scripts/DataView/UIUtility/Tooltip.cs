using UnityEngine;
using UnityEngine.EventSystems;
using ViewUtility;

namespace UIUtility
{
    public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public DataView source;
        public DataView target;

        public void OnPointerEnter(PointerEventData eventData) => target.SetData(source.GetData());
        public void OnPointerExit(PointerEventData eventData) => target.SetData(null);
    }
}