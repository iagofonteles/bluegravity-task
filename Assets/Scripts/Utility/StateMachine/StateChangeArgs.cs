namespace StateMachines
{
    public struct StateChangeArgs {
        public IMachineState State { get; }
        public object Ctx { get; }

        public StateChangeArgs(IMachineState state, object ctx) {
            State = state;
            Ctx = ctx;
        }
    }
}