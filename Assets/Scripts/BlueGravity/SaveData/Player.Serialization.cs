using System;
using System.Linq;
using UnityEngine;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public partial class Player : IGameSave
    {
        [SerializeField] private string[] equipmentsSerialized = new string[3];
        [SerializeField] private string[] hotbarSerialized = new string[10];

        /// <summary> Simplify data structures to serialize. </summary>
        void IGameSave.Save(string folder)
        {
            equipmentsSerialized = _equipments.Select(i => i.Value.name).ToArray();
            hotbarSerialized = _hotbar.Select(i => (i.Item as ItemSO)?.name).ToArray();
            IYamlGameSave.SaveData(folder, this);
        }

        /// <summary> Rebuild simplified data structures. </summary>
        object IGameSave.Load(string folder)
        {
            var player = IYamlGameSave.LoadData(folder, this) as Player;

            var index = 0;
            foreach (var name in player.equipmentsSerialized)
                player._equipments[index++].Value = Game.Database.Get<ItemSO>(name);

            index = 0;
            foreach (var name in player.hotbarSerialized)
                player._hotbar[index++].Item = Game.Database.Get<ItemSO>(name);

            return player;
        }
    }
}