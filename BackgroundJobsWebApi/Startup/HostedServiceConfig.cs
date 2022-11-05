using BackgroundJobsWebApi.Workers;

namespace BackgroundJobsWebApi.Startup
{
    public class HostedServiceConfig
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddHostedService<EmailSendingWorker>();
        }
    }
}
