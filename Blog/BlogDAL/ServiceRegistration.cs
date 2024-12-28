using BlogDAL.Repostories;
using Microsoft.Extensions.DependencyInjection;
namespace BlogDAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepostories(this IServiceCollection services)
        {
            services.AddScoped(ICategoryRepostory, CategoryRepostory)();
            return services;
        }
    }
}
