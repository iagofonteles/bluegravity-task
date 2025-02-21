using TMPro;
using UnityEngine;

namespace UIUtility
{
    [RequireComponent(typeof(TMP_Text))]
    public class FormattedTextSetter : MonoBehaviour
    {
        public string format;
        public void SetText(string text) => GetComponent<TMP_Text>().text = string.Format(format, text);
        public void SetText(int value) => SetText(value.ToString());
        public void SetText(float value) => SetText(value.ToString());
        public void SetText(bool value) => SetText(value.ToString());
        public void SetText(long value) => SetText(value.ToString());
        public void SetText(short value) => SetText(value.ToString());
        public void SetText(double value) => SetText(value.ToString());
        public void SetText(decimal value) => SetText(value.ToString());
        public void SetText(char value) => SetText(value.ToString());
    }
}