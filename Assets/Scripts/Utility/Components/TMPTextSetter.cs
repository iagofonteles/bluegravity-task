using TMPro;
using UnityEngine;

namespace UIUtility
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMPTextSetter : MonoBehaviour
    {
        public void SetText(string value) => GetComponent<TMP_Text>().text = value;
        public void SetText(object value) => SetText(value.ToString());
        public void SetText(bool value) => SetText(value.ToString());
        public void SetText(char value) => SetText(value.ToString());
        public void SetText(int value) => SetText(value.ToString());
        public void SetText(float value) => SetText(value.ToString());
        public void SetText(double value) => SetText(value.ToString());
        public void SetText(decimal value) => SetText(value.ToString());
        public void SetText(long value) => SetText(value.ToString());
        public void SetText(short value) => SetText(value.ToString());
    }
}