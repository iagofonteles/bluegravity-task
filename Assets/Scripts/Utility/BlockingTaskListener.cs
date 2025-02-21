using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class BlockingTaskListener : BlockingTaskListener<BlockingTask> { }

    public abstract class BlockingTaskListener<T> : MonoBehaviour
    {
        public UnityEvent onBusy;
        public UnityEvent onFree;

        private void Awake() => BlockingTask<T>.IsBusy.OnValueChanged += OnBusyChanged;
        private void OnDestroy() => BlockingTask<T>.IsBusy.OnValueChanged -= OnBusyChanged;

        private void OnBusyChanged(bool newvalue, bool oldvalue)
        {
            if (newvalue) onBusy.Invoke();
            else onFree.Invoke();
        }
    }
}