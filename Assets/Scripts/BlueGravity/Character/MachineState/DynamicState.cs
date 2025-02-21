using System;
using StateMachines;
using UnityEngine;

namespace BlueGravity.CharacterStates
{
    public class DynamicStateArgs
    {
        public string animation;
        public Action trigger;
        public bool moveToCancel = true;
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
                case "trigger": args.trigger?.Invoke(); break;
            }
        }
    }
}