using System;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class PlayerInfo : IJsonGameSave
    {
        [SerializeField] private string displayName;
        [SerializeField] private Vector3 position;

        public string DisplayName => displayName;
        public Vector3 Position => position;
    }
}