using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.UI
{
    public class LocalizationListener : MonoBehaviour
    {
        public UnityEvent<string> onLanguageChanged;
        private void Start() => Game.I18n.OnLanguageChanged += onLanguageChanged.Invoke;
        private void OnDestroy() => Game.I18n.OnLanguageChanged -= onLanguageChanged.Invoke;
    }
}