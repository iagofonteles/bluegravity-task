using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachines
{
    public class StateMachine : MonoBehaviour, IStateMachine
    {
        [SerializeReference] string currentStateType;
        [SerializeReference] IMachineState currentState;
        IMachineState DefaultState { get; set; }
        Dictionary<object, IMachineState> states = new();

        public object Subject { get; private set; }
        public IMachineState CurrentState { get; private set; }
        public IReadOnlyDictionary<object, IMachineState> States => states;

        /// <summary>First state will be the fallback.</summary>
        public void StartMachine(object subject, IMachineState defaultState)
            => StartMachine(subject, new[] { defaultState });

        public void StartMachine(object subject, IEnumerable<IMachineState> defaultStates)
        {
            if (Subject is not null) throw new Exception("Machine already started.");
            Subject = subject;
            DefaultState = defaultStates.FirstOrDefault();
            foreach (var s in defaultStates) AddState(s);
            SetState(DefaultState, null);
        }

        public bool AddState(IMachineState state)
        {
            if (states.ContainsKey(state.Key)) return false;
            states[state.Key] = state;
            state.Machine = this;
            state.OnAttatch(this);
            return true;
        }

        public bool RemoveState(object key)
        {
            if (key is null) return false;
            var removed = states.Remove(key, out var s);
            if (removed)
            {
                s.OnDetatch(this);
                s.Machine = null;
                if (CurrentState == s)
                    SetState(null);
            }

            return removed;
        }

        public bool TryChangeState(object key, object ctx = null)
        {
            if (!states.TryGetValue(key, out var state))
                return false;
            SetState(state, ctx);
            return true;
        }

        public void SetState<T>(object ctx = null) => SetState(typeof(T), ctx);

        public void SetState(object key, object ctx = null)
        {
            var next = key == null ? null : states.GetValueOrDefault(key);
            SetState(next ?? DefaultState, ctx);
        }

        void SetState(IMachineState state, object ctx)
        {
            CurrentState?.OnExit(Subject, new(state, ctx));
            state?.OnEnter(Subject, new(CurrentState, ctx));
            CurrentState = state;
            currentState = CurrentState;
            currentStateType = CurrentState.ToString();
        }

        public IMachineState GetState(object key) => states.TryGetValue(key, out var state) ? state : null;
        public T FindState<T>() => GetState(typeof(T)) is T state ? state : default;
        public void ResetState() => SetState(DefaultState, null);
        protected virtual void Update() => CurrentState?.OnUpdate(Subject);
        protected virtual void FixedUpdate() => CurrentState?.OnFixedUpdate(Subject);
    }
}