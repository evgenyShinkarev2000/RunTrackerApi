using Microsoft.Extensions.DependencyInjection;

namespace RunTrackerApi.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IRunRecordService, RunRecordService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
