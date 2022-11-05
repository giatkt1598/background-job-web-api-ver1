using BackgroundJobsWebApi.Service.Services.Abstracts;
using BackgroundJobsWebApi.Service.Services.Concretes;

namespace BackgroundJobsWebApi.Startup
{
    public class DependencyInjectionConfig
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBackgroundJobService, BackgroundJobService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
        }
    }
}
