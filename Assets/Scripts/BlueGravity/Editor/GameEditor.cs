using UnityEditor;
using TypeCache = Utility.TypeCache;

namespace BlueGravity.Editor
{
    public class GameEditor
    {
        [InitializeOnLoadMethod]
        static void InitEditor()
        {
            TypeCache.SetAssemblies(new[] { typeof(Item).Assembly });
        }
    }
}