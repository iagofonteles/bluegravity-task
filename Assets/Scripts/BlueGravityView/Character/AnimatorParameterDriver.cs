using System;
using UnityEngine;

namespace BlueGravityView
{
    public class AnimatorParameterDriver : MonoBehaviour
    {
        public Transform model;
        public Animator animator;
        public string speed = "speed";
        public float maxSpeed = 5;

        private Vector3 _lastPosition;


        private void Update()
        {
            var delta = model.position - _lastPosition;
            _lastPosition = model.position;
            animator.SetFloat(speed, delta.magnitude / (maxSpeed * Time.deltaTime));
        }
    }
}