namespace BlueGravity
{
    public class GameSaveComponent : UnityEngine.MonoBehaviour
    {
        public void Save() => Game.Save.Save();
        public void Load(string saveName) => Game.Save.Load(saveName);
    }
}