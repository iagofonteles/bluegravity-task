using UnityEngine;
using UnityEngine.UI;

namespace UIUtility
{
    public class SliderValueSetter : MonoBehaviour
    {
        public void SetValue(int value) => GetComponent<Slider>().value = value;
        public void SetValue(double value) => GetComponent<Slider>().value = (float)value;
        public void SetValue(short value) => GetComponent<Slider>().value = value;
        public void SetValue(long value) => GetComponent<Slider>().value = value;
        public void SetMaxValue(int value) => GetComponent<Slider>().maxValue = value;
        public void SetMaxValue(double value) => GetComponent<Slider>().maxValue = (float)value;
        public void SetMaxValue(short value) => GetComponent<Slider>().maxValue = value;
        public void SetMaxValue(long value) => GetComponent<Slider>().maxValue = value;
    }
}