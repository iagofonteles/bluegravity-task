using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [CreateAssetMenu(menuName = "Game/Item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] private Sprite icon;
        [SerializeField] private string description;
        [SerializeField] private int price;
        [SerializeField] private int maxStack;
        [SerializeField] private string type;
        [SerializeField] private string[] tags;
        [SerializeField] private TypeInstances<IItemScript> scripts;

        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public string Description => description;
        public int Price => price;
        public int MaxStack => maxStack;
        public string Type => type;
        public string[] Tags => tags;

        public T GetScript<T>() where T : IItemScript => scripts.OfType<T>().FirstOrDefault();
    }
}