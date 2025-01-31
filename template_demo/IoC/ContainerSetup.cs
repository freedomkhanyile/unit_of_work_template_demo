using template_demo.Application;
using template_demo.Persistence;

namespace template_demo.Api.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddCors();
            services.AddPersistence(configuration);
            services.AddApplication();
            
        }

        private static void AddCors(this IServiceCollection services)
        {
            services
             .AddCors(options =>
             {
                 options
                     .AddPolicy("CorsPolicy",
                     builder =>
                        builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod());
             });
        }
    }
}
