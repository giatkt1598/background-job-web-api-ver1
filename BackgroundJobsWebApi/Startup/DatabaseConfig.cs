using BackgroundJobsWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJobsWebApi.Startup
{
    public class DatabaseConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<BackgroundJobDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("BackgroundJobDb"));
            });
        }

        public static void MigrateDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BackgroundJobDbContext>();
            db.Database.Migrate();
        }
    }
}
