namespace StateMachines
{
    public interface IMachineState {
        object Key { get; }
        IStateMachine Machine { get; set; }
        void OnAttatch(IStateMachine machine);
        void OnDetatch(IStateMachine machine);
        void OnEnter(object subject, StateChangeArgs prev);
        void OnExit(object subject, StateChangeArgs next);
        void OnUpdate(object subject);
        void OnFixedUpdate(object subject);
        void ReceiveMessage(object message);
    }
}