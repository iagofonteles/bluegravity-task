namespace BlueGravity
{
    public interface IItemScript { }

    public interface IUsabeItem : IItemScript
    {
        bool ConsumeOnUse { get; }
        bool TryUse(object context);
    }
}