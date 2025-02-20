using UnityEngine;

namespace BlueGravity.CharacterComponents
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] CharacterController body;
        [SerializeField] Animator animator;
        [SerializeField] SpriteRenderer sprite;

        public float speed = 4;
        public bool lockSide;

        public int Side { get; private set; }

        public bool Move(Vector3 direction) => Move(direction, speed);

        public bool Move(Vector3 direction, float speed)
        {
            if (!enabled) return false;
            direction.Normalize();
            var velocity = direction * speed;
            var coll = body.Move(velocity * Time.deltaTime);
            animator.SetFloat("speed", velocity.magnitude / speed);
            UpdateSide(velocity.x, false);
            return coll == CollisionFlags.None;
        }

        public void UpdateSide(float xSpeed, bool force)
        {
            if ((lockSide && !force) || xSpeed == 0) return;
            Side = xSpeed < 0 ? -1 : 1;
            body.transform.localScale = xSpeed < 0 ? left : Vector3.one;
        }

        readonly Vector3 left = new Vector3(-1, 1, 1);
    }
}