using Drafts.Internationalization;
using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.UI
{
    public class TranslatedText : MonoBehaviour
    {
        public string table, key;
        public UnityEvent<string> onTextChanged;

        private I18nEntry _entry;

        private void Start()
        {
            Game.I18n.OnLanguageChanged += UpdateText;
            UpdateText(null);
        }

        private void OnDestroy() => Game.I18n.OnLanguageChanged -= UpdateText;
        void UpdateText(string _) => onTextChanged.Invoke(_entry ??= Game.I18n.GetTable(table)[key]);
    }
}