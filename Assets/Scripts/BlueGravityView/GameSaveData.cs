using UnityEngine;
using Utility;
using ViewUtility;

namespace BlueGravity.UI
{
    /// <summary>
    /// feed an object from Game.Save into object DataView 
    /// </summary>
    public class GameSaveData : MonoBehaviour
    {
        public bool overrideData;
        [TypeInstance, SerializeReference] private IGameSave saveData;

        void Awake()
        {
            if (overrideData) Game.Save.Set(saveData);
        }

        private void Start()
        {
            saveData = Game.Save.Get(saveData.GetType());
            GetComponent<DataView>()?.SetData(saveData);
        }
    }
}