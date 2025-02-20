using BlueGravity.CharacterComponents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueGravity.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement movement;

        Vector3 _direction;

        private void Update()
        {
            movement.Move(_direction);
        }

        public void OnMove(InputValue value)
        {
            var v = value.Get<Vector2>();
            _direction = new(v.x, 0, v.y);
        }
    }
}