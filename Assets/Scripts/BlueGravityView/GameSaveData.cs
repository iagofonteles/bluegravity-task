using UnityEngine;
using Utility;
using ViewUtility;

namespace BlueGravity.UI
{
    public class GameSaveData : MonoBehaviour
    {
        [TypeInstance, SerializeReference] private IGameSave saveData;
        public bool overrideData;

        void OnEnable()
        {
            if (overrideData) Game.Save.Set(saveData);
            else saveData = Game.Save.Get(saveData.GetType());
            GetComponent<DataView>()?.SetData(saveData);
        }
    }
}