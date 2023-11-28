using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IMyPasswordService _myPasswordService;
        private readonly IAuthService _authService;

        public ServiceManager(ICategoryService categoryService, IMyPasswordService myPasswordService, IAuthService authService)
        {
            _categoryService = categoryService;
            _myPasswordService = myPasswordService;
            _authService = authService;
        }

        public ICategoryService CategoryService => _categoryService;
        public IMyPasswordService MyPasswordService => _myPasswordService;
        public IAuthService AuthService => _authService;
    }
}
