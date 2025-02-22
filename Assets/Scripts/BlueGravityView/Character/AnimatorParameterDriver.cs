using BlueGravity;
using UnityEngine;

namespace BlueGravityView
{
    public class AnimatorParameterDriver : MonoBehaviour
    {
        public Transform model;
        public Animator animator;
        public Character character;
        public string speed = "speed";
        public float threshold = 2f;

        private Vector3 _lastPosition;

        private void Update()
        {
            var delta = model.position - _lastPosition;
            _lastPosition = model.position;

            var moveSpeed = character.Player.Stats.MoveSpeed.Value;

            var animSpeed = 0f;
            if (delta.magnitude > .05)
                animSpeed = moveSpeed > threshold ? 2 : 1;

            animator.SetFloat(speed, animSpeed);
        }
    }
}