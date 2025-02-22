using System;
using StateMachines;
using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.CharacterStates
{
    [Serializable]
    public class DynamicStateArgs
    {
        public string animation;
        public bool moveToCancel = true;
        public UnityEvent<Character> trigger;
    }

    public class DynamicState : CharacterState
    {
        private DynamicStateArgs args;

        public override void OnEnter(object subject, StateChangeArgs prev)
        {
            if (prev.Ctx is not DynamicStateArgs args)
            {
                Debug.LogError("Context is not DynamicStateArgs: " + prev.Ctx);
                Machine.SetState(null);
                return;
            }

            this.args = args;
            base.OnEnter(subject, prev);

            if (!string.IsNullOrEmpty(args.animation))
                Character.Animator.Play(args.animation);

            if (args.moveToCancel)
                Character.Input.Move += _ => Machine.SetState(null);
        }

        public override void ReceiveMessage(object message)
        {
            switch (message)
            {
                case "return": Machine.SetState(null); break;
                case "trigger": args.trigger?.Invoke(Character); break;
            }
        }
    }
}