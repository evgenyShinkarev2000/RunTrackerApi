using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RunTrackerApi.Data.Repositories;


namespace RunTrackerApi.Data
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppData(this IServiceCollection services, string postgreeSqlConnectionString)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseNpgsql(postgreeSqlConnectionString);
            });

            services.AddScoped<IRunRecordCoverRepository, RunRecordCoverRepository>();
            services.AddScoped<IRunRecordCoverMetaRepository, RunRecordCoverMetaRepository>();
        }
    }
}
