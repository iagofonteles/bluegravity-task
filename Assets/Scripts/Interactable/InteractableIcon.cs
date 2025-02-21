using UnityEngine;
using UnityEngine.Events;

namespace Interactable
{
    [RequireComponent(typeof(IInteractable))]
    public class InteractableIcon : MonoBehaviour
    {
        public UnityEvent<bool> onAgentsNearby;

        private void Start()
        {
            var list = GetComponent<IInteractable>().InteractorsInRange;
            list.CollectionChanged += (_, _) => onAgentsNearby.Invoke(list.Count > 0);
            onAgentsNearby.Invoke(list.Count > 0);
        }
    }
}