namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        public IMyPasswordRepository MyPasswordRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        void Save();
    }
}
