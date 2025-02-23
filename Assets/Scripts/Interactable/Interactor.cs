using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Interactable
{
    public class Interactor : MonoBehaviour, IInteractor
    {
        [SerializeField] private float range;
        public UnityEvent<IInteractable> OnNearestChanged;

        public Vector3 Position => transform.position;
        public float Range => range;
        public Observable<IInteractable> NearestInteracble { get; } = new();

        private void Awake()
        {
            NearestInteracble.OnValueChanged += (n, _) => OnNearestChanged.Invoke(n);
            OnNearestChanged.Invoke(NearestInteracble.Value);
        }

        private void Update() => ((IInteractor)this).UpdateInteractable();
        private void OnDisable() => NearestInteracble.Value = null;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}