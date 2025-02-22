using UnityEngine;
using UnityEngine.Events;

namespace Utility.Components
{
    public class Progressor : MonoBehaviour
    {
        [Range(0, 1)] public float progress;
        [Min(0)] public float duration = .5f;
        public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
        public UnityEvent<float> onUpdate;
        public UnityEvent onFinished;

        public void Play()
        {
            progress = 0;
            enabled = true;
        }

        public void SetProgress(float value)
        {
            progress = value;
            onUpdate.Invoke(curve.Evaluate(value));
        }

        private void Update()
        {
            var value = progress + Time.deltaTime / duration;
            SetProgress(Mathf.Min(1, value));

            if (progress < 1) return;

            SetProgress(1);
            onFinished.Invoke();
            enabled = false;
        }

        private void OnValidate()
        {
            onUpdate.Invoke(curve.Evaluate(progress));
        }
    }
}