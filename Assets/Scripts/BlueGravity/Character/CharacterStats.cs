using System;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class CharacterStats
    {
        [SerializeField] private Observable<int> health = new();
        [SerializeField] private Observable<int> mana = new();
        [SerializeField] private Observable<float> moveSpeed = new(5);

        public Observable<int> Health => health;
        public Observable<int> Mana => mana;
        public Observable<float> MoveSpeed => moveSpeed;
    }
}