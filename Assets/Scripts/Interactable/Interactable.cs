using System;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Interactable
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private float range;
        public UnityEvent<object> onInteract;

        public Vector3 Position => transform.position;
        public float Range => range;
        public ObservableList<IInteractor> InteractorsInRange { get; } = new();

        public void Interact(object interactor) => onInteract.Invoke(interactor);
        private void OnEnable() => IInteractable.Active.Add(this);
        private void OnDisable() => IInteractable.Active.Remove(this);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}