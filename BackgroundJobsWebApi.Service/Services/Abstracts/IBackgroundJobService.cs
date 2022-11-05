using BackgroundJobsWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Service.Services.Abstracts
{
    public interface IBackgroundJobService
    {
        void Enqueue<TArgs>(string jobName, TArgs args, int priority = 0) where TArgs : class;
        AppBackgroundJob? Dequeue(string jobName);
        void DeleteJob(Guid id);
        void JobError(Guid id, Exception ex);
    }
}
