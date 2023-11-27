namespace Services.Contracts
{
    public interface IIdentityUserService
    {
        Task<string> GetIdentityUserIdrwithIdentityUserNameAsync(string userName);
    }
}
