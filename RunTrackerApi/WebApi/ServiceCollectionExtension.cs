using Microsoft.Extensions.DependencyInjection;
using RunTrackerApi.WebApi.Mappers;
using RunTrackerApi.WebApi.Mappers.ToData;
using RunTrackerApi.WebApi.Mappers.ToWebApi;

namespace RunTrackerApi.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppWebApi(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile<WebApiToDataAutoMapperProfile>();
                options.AddProfile<DataToWebApiAutoMapperProfile>();
            });
            services.AddSingleton<TimeSpanConverter>();
            services.AddSingleton<DateTimeConverter>();

            services.AddSingleton<IRunRecordCoverToData, RunRecordCoverToData>();
            services.AddSingleton<IRunRecordCoverToWebApi, RunRecordCoverToWebApi>();
        }
    }
}
