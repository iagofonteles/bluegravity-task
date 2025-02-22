using System.Collections.Generic;

namespace StateMachines
{
    public interface IStateMachine {
        IMachineState CurrentState { get; }
        IReadOnlyDictionary<object, IMachineState> States { get; }
        object Subject { get; }

        bool AddState(IMachineState state);
        bool RemoveState(object key);
        IMachineState GetState(object key);
        void SetState(object key, object ctx = null);
        bool TryChangeState(object key, object ctx = null);
        void StartMachine(object subject, IEnumerable<IMachineState> defaultStates);
    }
}