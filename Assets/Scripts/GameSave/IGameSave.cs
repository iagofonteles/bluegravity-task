namespace Utility
{
    public interface IGameSave
    {
        void Save(string folder);
        IGameSave Load(string folder);
    }
}