using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IMyPasswordService _myPasswordService;
        private readonly IIdentityUserService _identityUserService;

        public ServiceManager(ICategoryService categoryService, IMyPasswordService myPasswordService, IIdentityUserService identityUserService)
        {
            _categoryService = categoryService;
            _myPasswordService = myPasswordService;
            _identityUserService = identityUserService;
        }

        public ICategoryService CategoryService => _categoryService;
        public IMyPasswordService MyPasswordService => _myPasswordService;

        public IIdentityUserService IdentityUserService => _identityUserService;
    }
}
