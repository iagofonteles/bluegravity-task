using UnityEngine;

namespace BlueGravityView
{
    [ExecuteAlways]
    public class RotationRealtiveToCamera : MonoBehaviour
    {
        private void Start()
        {
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
    }
}