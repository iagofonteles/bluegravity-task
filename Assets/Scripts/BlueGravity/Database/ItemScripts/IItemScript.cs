namespace BlueGravity
{
    public interface IItemScript { }
}

namespace BlueGravity.ItemScripts
{
    public interface IUsabeItem : IItemScript
    {
        bool ConsumeOnUse { get; }
        bool TryUse(object context);
    }
}