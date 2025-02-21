using System;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class CharacterStats
    {
        [SerializeField] private Observable<int> health = new(100);
        [SerializeField] private Observable<int> mana = new(100);
        [SerializeField] private Observable<int> miningPower = new(1);
        [SerializeField] private Observable<float> moveSpeed = new(1);

        public Observable<int> Health => health;
        public Observable<int> Mana => mana;
        public Observable<int> MiningPower => miningPower;
        public Observable<float> MoveSpeed => moveSpeed;
    }
}