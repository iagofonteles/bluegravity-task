using UnityEngine;
using Utility;

namespace ViewUtility
{
    public class LocalData : MonoBehaviour
    {
        [TypeInstance, SerializeReference] private object data;
        void Start() => GetComponent<IDataView>()?.SetData(data);
    }
}