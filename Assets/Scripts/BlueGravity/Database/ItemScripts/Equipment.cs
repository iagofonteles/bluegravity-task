using System;
using UnityEngine;

namespace BlueGravity.ItemScripts
{
    [Serializable]
    public class Equipment : IItemScript
    {
        [SerializeField] private EquipmentSlot slot;
        [SerializeField] private float moveSpeedMultiplier;
        [SerializeField] private int mininPower;

        public EquipmentSlot Slot => slot;
        public float MoveSpeedMultiplier => moveSpeedMultiplier;
        public int MininPower => mininPower;
    }
}