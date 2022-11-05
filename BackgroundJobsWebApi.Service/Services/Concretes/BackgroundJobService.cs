using BackgroundJobsWebApi.Domain.Entities;
using BackgroundJobsWebApi.Service.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Service.Services.Concretes
{
    public class BackgroundJobService: IBackgroundJobService
    {
        private readonly BackgroundJobDbContext _dbContext;

        public BackgroundJobService(BackgroundJobDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Enqueue<TArgs>(string jobName, TArgs args, int priority = 0) where TArgs : class
        {
            var job = new AppBackgroundJob
            {
                JobName = jobName,
                JobArgs = JsonConvert.SerializeObject(args),
                CreationTime = DateTime.Now,
                Priority = priority
            };
            _dbContext.Add(job);
            _dbContext.SaveChanges();
        }

        public AppBackgroundJob? Dequeue(string jobName)
        {
            var job = _dbContext.AppBackgroundJobs
                .AsNoTracking()
                .Where(x => x.JobName == jobName && !x.IsFailure)
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.CreationTime)
                .FirstOrDefault();
            return job;
        }

        public void JobError(Guid id, Exception ex)
        {
            var job = _dbContext.AppBackgroundJobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                job.IsFailure = true;
                job.Detail = ex.ToString();
                _dbContext.SaveChanges();
            }
        }

        public void DeleteJob(Guid id)
        {
            var job = _dbContext.AppBackgroundJobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                _dbContext.AppBackgroundJobs.Remove(job);
                _dbContext.SaveChanges();
            }
        }
    }
}
