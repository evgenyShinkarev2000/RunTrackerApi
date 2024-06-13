using Microsoft.Extensions.DependencyInjection;

namespace RunTrackerApi.Authorization
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppAuthorization(this IServiceCollection services)
        {
            services.AddCors();
        }
    }
}
