using UnityEngine;
using UnityEngine.Events;

namespace Utility.Triggers
{
    public class TriggerOnLifecycle : MonoBehaviour
    {
        public UnityEvent onStart;
        public UnityEvent onAwake;
        public UnityEvent onEnabled;
        public UnityEvent onDisable;
        public UnityEvent onDestroyed;

        private void Awake() => onAwake.Invoke();
        private void Start() => onStart.Invoke();
        private void OnEnable() => onEnabled.Invoke();
        private void OnDisable() => onDisable.Invoke();
        private void OnDestroy() => onDestroyed.Invoke();
    }
}