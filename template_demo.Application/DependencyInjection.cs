using Microsoft.Extensions.DependencyInjection;
using template_demo.Application.Repositories;
using uow = template_demo.Application.UnitOfWork;

namespace template_demo.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<uow.IUnitOfWork, uow.UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
        }
    }
}
