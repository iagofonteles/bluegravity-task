using System.Linq;
using UnityEngine;
using Utility;
using Drafts.Internationalization;

namespace BlueGravity
{
    [CreateAssetMenu(menuName = "Game/Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private int price;
        [SerializeField] private int maxStack;
        [SerializeField] private string type;
        [SerializeField] private string[] tags;
        [SerializeField] private TypeInstances<IItemScript> scripts;
        [SerializeField] private Sprite icon;

        private I18nEntry displayName;
        private I18nEntry description;

        public string DisplayName => displayName ??= Game.I18n.GetTable("itemso")[name];
        public Sprite Icon => icon;
        public string Description => description ??= Game.I18n.GetTable("itemso")[name + " desc"];
        public int Price => price;
        public int MaxStack => maxStack;
        public string Type => type;
        public string[] Tags => tags;

        public T GetScript<T>() where T : IItemScript => scripts.OfType<T>().FirstOrDefault();
    }
}