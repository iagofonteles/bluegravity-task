using UnityEngine;
using UnityEngine.Events;

namespace Utility.Triggers
{
    public class TriggerOnCondition : MonoBehaviour
    {
        public float comparer;
        public UnityEvent<bool> onConditionMet;
        public UnityEvent<bool> onConditionNotMet;

        public void Trigger(bool conditionMet)
        {
            onConditionMet.Invoke(conditionMet);
            onConditionNotMet.Invoke(!conditionMet);
        }

        public void IsNull(object value) => Trigger(value == null);
        public void IsNotNull(object value) => Trigger(value == null);

        public void IsNullOrEmpty(string value) => Trigger(string.IsNullOrEmpty(value));

        public void IsZero(int value) => Trigger(value == 0);
        public void IsNotZero(int value) => Trigger(value != 0);

        public void IsZero(float value) => Trigger(value == 0);
        public void IsNotZero(float value) => Trigger(value != 0);

        public void Greater(int value) => Trigger(value > comparer);
        public void GreaterOrEquals(int value) => Trigger(value >= comparer);

        public void Greater(float value) => Trigger(value > comparer);
        public void GreaterOrEquals(float value) => Trigger(value >= comparer);
        
        public void Less(int value) => Trigger(value < comparer);
        public void LessOrEquals(int value) => Trigger(value <= comparer);

        public void Less(float value) => Trigger(value < comparer);
        public void LessOrEquals(float value) => Trigger(value <= comparer);
    }
}