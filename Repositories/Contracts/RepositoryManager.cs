namespace Repositories.Contracts
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMyPasswordRepository _myPasswordRepository;

        public RepositoryManager(RepositoryContext repositoryContext, ICategoryRepository categoryRepository, IMyPasswordRepository myPasswordRepository)
        {
            _repositoryContext = repositoryContext;
            _categoryRepository = categoryRepository;
            _myPasswordRepository = myPasswordRepository;
        }

        public IMyPasswordRepository MyPasswordRepository => _myPasswordRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
