using UnityEngine;

namespace BlueGravity.CharacterComponents
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] CharacterController body;
        public bool lockSide;

        public int Side { get; private set; }

        public bool Move(Vector3 direction, float speed)
        {
            if (!enabled) return false;
            direction.Normalize();
            var velocity = direction * speed;
            var coll = body.Move(velocity * Time.deltaTime);

            var pos = body.transform.position;
            pos.y = 0;
            body.transform.position = pos;

            UpdateSide(velocity.x, false);
            return coll == CollisionFlags.None;
        }

        public void UpdateSide(float xSpeed, bool force)
        {
            if ((lockSide && !force) || xSpeed == 0) return;
            Side = xSpeed < 0 ? -1 : 1;

            var scale = body.transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            scale.x = Mathf.Abs(scale.x) * xSpeed < 0 ? -1 : 1;
            body.transform.localScale = scale;
        }
    }
}