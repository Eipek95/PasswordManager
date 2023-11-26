using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IMyPasswordService _myPasswordService;

        public ServiceManager(ICategoryService categoryService, IMyPasswordService myPasswordService)
        {
            _categoryService = categoryService;
            _myPasswordService = myPasswordService;
        }

        public ICategoryService CategoryService => _categoryService;
        public IMyPasswordService MyPasswordService => _myPasswordService;
    }
}
