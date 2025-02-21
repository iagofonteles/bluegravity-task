using StateMachines;
using UnityEngine;

namespace BlueGravity.CharacterStates
{
    public class IdleState : CharacterState
    {
        public override void OnEnter(object subject, StateChangeArgs prev)
        {
            base.OnEnter(subject, prev);
            Character.Animator.Play("Idle");
            Character.Input.Interact += TryIntract;
        }

        void TryIntract(bool pressed)
        {
            if (!pressed) return;
            Character.Interactor.TryInteract(Character);
        }

        public override void OnUpdate(object subject)
        {
            var speed = Character.Stats.MoveSpeed.Value;
            var dir = Character.Input.Direction;
            if (dir.sqrMagnitude > 0)
                Character.Movement.Move(dir, speed);
        }
    }
}