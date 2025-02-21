using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueGravity.CharacterComponents
{
    public class InputMapper : MonoBehaviour
    {
        public Vector3 Direction { get; private set; }

        public event Action<Vector3> Move;
        public event Action<bool> Bag;
        public event Action<bool> Attack;
        public event Action<bool> Interact;
        public event Action<bool> Special;
        public event Action<bool> Pause;

        private void OnMove(Vector2 dir)
        {
            Direction = new Vector3(dir.x, 0, dir.y);
            Move?.Invoke(Direction);
        }

        private void OnMove(InputValue v) => OnMove(v.Get<Vector2>());
        private void OnBag(InputValue v) => Bag?.Invoke(v.isPressed);
        private void OnAttack(InputValue v) => Attack?.Invoke(v.isPressed);
        private void OnInteract(InputValue v) => Interact?.Invoke(v.isPressed);
        private void OnSpecial(InputValue v) => Special?.Invoke(v.isPressed);
        private void OnPause(InputValue v) => Pause?.Invoke(v.isPressed);

        public void ResetDirection() => Direction = Vector3.zero;

        public void UnmapAll()
        {
            Move = null;
            Bag = null;
            Attack = null;
            Interact = null;
            Special = null;
            Pause = null;
        }
    }
}