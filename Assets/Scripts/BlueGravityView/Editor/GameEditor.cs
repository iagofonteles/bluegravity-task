using UnityEditor;

namespace BlueGravity.Editor
{
    public class GameEditor
    {
        [InitializeOnLoadMethod]
        static void InitEditor() => Internal.GameInitialize.Init();
    }
}