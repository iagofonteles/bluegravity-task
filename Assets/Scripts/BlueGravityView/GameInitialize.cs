using UnityEngine;
using Utility;
using ViewUtility;

namespace BlueGravity.Internal
{
    public class GameInitialize
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Init()
        {
            TypeCache.SetAssemblies(new[]
            {
                typeof(ItemSO).Assembly,
                typeof(ItemView).Assembly,
                typeof(DataView).Assembly,
            });
        }
    }
}