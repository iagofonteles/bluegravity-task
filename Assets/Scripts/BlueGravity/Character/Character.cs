using BlueGravity.CharacterComponents;
using Interactable;
using StateMachines;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    public class Character : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Animator animator;
        [SerializeField] private InputMapper input;
        [SerializeField] private CharacterMovement movement;
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private Interactor interactor;

        [Header("Stats")]
        [SerializeField] private CharacterStats stats;
        [SerializeField] private TypeInstances<IMachineState> states;

        public Animator Animator => animator;
        public InputMapper Input => input;
        public CharacterMovement Movement => movement;
        public StateMachine StateMachine => stateMachine;
        public CharacterStats Stats => stats;
        public IInteractor Interactor => interactor;

        public ItemBag Inventory { get; private set; }
        public MoneyBag Money { get; private set; }

        private void Awake()
        {
            stateMachine.StartMachine(this, states);
            LoadCharacter();
        }

        void LoadCharacter()
        {
            Inventory = Game.Save.Get<ItemBag>();
            Money = Game.Save.Get<MoneyBag>();
            Game.Save.Get<CharacterStatsSave>().WriteTo(stats);
        }

        void SaveCharacter()
        {
            Game.Save.Get<CharacterStatsSave>().ReadFrom(stats);
        }
    }
}