using TMPro;
using UnityEngine;

namespace UIUtility
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMPTextSetter : MonoBehaviour
    {
        public void SetText(object value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(bool value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(string value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(char value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(int value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(float value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(double value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(decimal value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(long value) => GetComponent<TMP_Text>().text = value.ToString();
        public void SetText(short value) => GetComponent<TMP_Text>().text = value.ToString();
    }
}