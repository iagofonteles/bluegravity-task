using System;
using BlueGravity.CharacterComponents;
using Interactable;
using StateMachines;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputMapper input;
        [SerializeField] private CharacterMovement movement;
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private Interactor interactor;
        [SerializeField] private TypeInstances<IMachineState> states;

        public Animator Animator => animator;
        public InputMapper Input => input;
        public CharacterMovement Movement => movement;
        public StateMachine StateMachine => stateMachine;
        public IInteractor Interactor => interactor;

        public Player Player { get; private set; }

        public void SetPlayer(object data)
        {
            if (Player != null) return;
            if (data is not Player p)
                throw new Exception("data is not Player");

            Player = p;
            stateMachine.StartMachine(this, states);
        }
    }
}