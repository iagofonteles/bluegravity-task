using UnityEngine;

namespace BlueGravity.UI
{
    public class GatherSpot : MonoBehaviour
    {
        public ItemSO item;
        public string animation;
        public AudioClip sfx;
        public Sprite icon;

        [Header("fixed")] 
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private SpriteRenderer iconRenderer;
        [SerializeField] private DynamicCharacterAction dynamiAction;

        private void Start()
        {
            iconRenderer.sprite = icon;
            audioSource.clip = sfx;
            dynamiAction.stateArgs.animation = animation;
        }

        public void Gather(Character character)
        {
            var amount = character.Player.Stats.MiningPower.Value;
            character.Player.Inventory.Add(item, amount);
            audioSource.Play();
        }
    }
}