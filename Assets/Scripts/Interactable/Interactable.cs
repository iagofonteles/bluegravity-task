using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Interactable
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private float range;
        public UnityEvent<IInteractor> onInteract;
        public UnityEvent<ObservableList<IInteractor>> interactorsListChanged;

        public Vector3 Position => transform.position;
        public float Range => range;
        public ObservableList<IInteractor> InteractorsInRange { get; } = new();

        public void Interact(IInteractor interactor) => onInteract.Invoke(interactor);
        private void Start() => interactorsListChanged.Invoke(InteractorsInRange);
        private void OnEnable() => IInteractable.Active.Add(this);
        private void OnDisable() => IInteractable.Active.Remove(this);
    }
}