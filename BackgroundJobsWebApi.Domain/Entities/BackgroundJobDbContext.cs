using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Domain.Entities
{
    public class BackgroundJobDbContext : DbContext
    {
        public DbSet<AppBackgroundJob> AppBackgroundJobs { get; set; }
        public BackgroundJobDbContext(DbContextOptions<BackgroundJobDbContext> options) : base(options)
        {

        }

    }
}
