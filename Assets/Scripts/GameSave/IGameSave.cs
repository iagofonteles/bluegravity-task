namespace Utility
{
    public interface IGameSave
    {
        void Save(string folder);
        object Load(string folder);
    }
}