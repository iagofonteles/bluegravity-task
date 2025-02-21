using BlueGravity.CharacterComponents;
using StateMachines;

namespace BlueGravity.CharacterStates
{
    public abstract class CharacterState : IMachineState
    {
        public IStateMachine Machine { get; set; }
        public Character Character { get; private set; }
        public virtual object Key => GetType();

        public virtual void OnAttatch(IStateMachine machine) => Character = machine.Subject as Character;
        public virtual void OnDetatch(IStateMachine machine) => Character = null;
        public virtual void OnEnter(object subject, StateChangeArgs prev) => Character.Input.UnmapAll();
        public virtual void OnExit(object subject, StateChangeArgs next) { }
        public virtual void OnUpdate(object subject) { }
        public virtual void OnFixedUpdate(object subject) { }
        public virtual void ReceiveMessage(object message) { }
    }
}