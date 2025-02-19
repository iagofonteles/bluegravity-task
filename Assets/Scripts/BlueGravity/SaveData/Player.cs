using System;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class PlayerStats : IJsonGameSave
    {
        [SerializeField] private Observable<int> health = new();
        [SerializeField] private Observable<int> mana = new();

        public Observable<int> Health => health;
        public Observable<int> Mana => mana;
    }
}