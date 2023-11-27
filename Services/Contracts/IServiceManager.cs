namespace Services.Contracts
{
    public interface IServiceManager
    {
        public ICategoryService CategoryService { get; }
        public IMyPasswordService MyPasswordService { get; }
        public IIdentityUserService IdentityUserService { get; }
    }
}
