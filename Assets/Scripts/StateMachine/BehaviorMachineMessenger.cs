using UnityEngine;

namespace StateMachines
{
    public class StateMachineMessenger : MonoBehaviour
    {
        [SerializeField] StateMachine machine;

        public void SendStateMessage(string message)
            => machine.CurrentState.ReceiveMessage(message);
    }
}