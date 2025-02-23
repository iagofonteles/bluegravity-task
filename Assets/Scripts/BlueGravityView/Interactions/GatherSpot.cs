using TMPro;
using UnityEngine;

namespace BlueGravity.UI
{
    public class GatherSpot : MonoBehaviour
    {
        public ItemSO item;
        public string animation;
        public AudioClip sfx;
        public Sprite icon;
        public bool useMiningPower;

        [Header("fixed")] [SerializeField] private AudioSource audioSource;
        [SerializeField] private SpriteRenderer interactIcon;
        [SerializeField] private SpriteRenderer animationIcon;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private DynamicCharacterAction dynamiAction;

        private void Start()
        {
            interactIcon.sprite = icon;
            animationIcon.sprite = item.Icon;
            audioSource.clip = sfx;
            dynamiAction.stateArgs.animation = animation;
        }

        public void Gather(Character character)
        {
            var amount = useMiningPower ? 1 + character.Player.Stats.MiningPower.Value : 1;
            character.Player.Inventory.Add(item, amount);
            amountText.text = $"+{amount}";
            amountText.gameObject.SetActive(amount > 1);
        }
    }
}