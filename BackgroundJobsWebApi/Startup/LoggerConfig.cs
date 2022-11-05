using Serilog;

namespace BackgroundJobsWebApi.Startup
{
    public static class LoggerConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                .WriteTo.File("Logs/logs-.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 240)
                .WriteTo.Console()
                .CreateLogger();
            builder.Host.UseSerilog();

            Log.Logger.Information("Starting web host");
        }
    }
}
