using UnityEngine;

namespace Utility.Components
{
    public class LoggerComponent : MonoBehaviour
    {
        public void LogMessage(string message) => Debug.Log(message, this);
        public void LogWarning(string message) => Debug.LogWarning(message, this);
        public void LogError(string message) => Debug.LogError(message, this);
        
        public void Log(object message) => Debug.Log(message, this);
        public void Log(int message) => Debug.Log(message, this);
        public void Log(float message) => Debug.Log(message, this);
        public void Log(bool message) => Debug.Log(message, this);
    }
}