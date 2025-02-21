using StateMachines;

namespace BlueGravity.CharacterStates
{
    public class IdleState : CharacterState
    {
        public float moveSpeed = 5;

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
            var speed = Character.Player.Stats.MoveSpeed.Value;
            var dir = Character.Input.Direction;
            Character.Movement.Move(dir, moveSpeed * speed);
        }
    }
}