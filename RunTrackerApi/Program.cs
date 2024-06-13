using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RunTrackerApi.WebApi;
using RunTrackerApi.Data;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Hosting;
using RunTrackerApi.Services;
using RunTrackerApi.Authorization;
using System.Buffers.Text;
using System.Text;

namespace RunTrackerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddAppWebApi();
            builder.Services.AddAppData(builder.Configuration.GetConnectionString("PostgreSql") ?? throw new NullReferenceException());
            builder.Services.AddAppServices();
            builder.Services.AddAppAuthorization();

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            var app = builder.Build();

            //app.Use(async (context, next) =>
            //{
            //    var bytes = await context.Request.BodyReader.ReadAsync();
            //    var str = Encoding.Default.GetString(bytes.Buffer);

            //    await next();
            //});

            app.UseAppAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapSwagger();
            app.MapControllers();

            app.Run();
        }
    }
}
