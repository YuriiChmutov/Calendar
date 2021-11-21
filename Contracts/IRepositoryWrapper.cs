namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ITodoRepository ToDo { get; }
        void Save();
    }
}