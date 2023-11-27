using Microsoft.EntityFrameworkCore;
using PasswordManager.CustomValidators;
using PasswordManager.Localizations;
using Repositories;
using Repositories.Contracts;
using Repositories.Models;
using Services;
using Services.Contracts;

namespace PasswordManager.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("PasswordManager"));
            });
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMyPasswordRepository, MyPasswordRepository>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMyPasswordService, MyPasswordService>();
            services.AddScoped<IIdentityUserService, IdentityUserService>();

        }

        public static void ConfigureAddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            }).AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
            .AddEntityFrameworkStores<RepositoryContext>();
        }
    }
}
