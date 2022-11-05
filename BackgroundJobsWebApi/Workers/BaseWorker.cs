using BackgroundJobsWebApi.Service.Services.Abstracts;
using BackgroundJobsWebApi.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BackgroundJobsWebApi.Workers
{
    public abstract class BaseWorker<TArgs> : BackgroundService where TArgs : class
    {
        private readonly ILogger<BaseWorker<TArgs>> _logger;
        private readonly IBackgroundJobService _backgroundJobService;
        protected readonly string JobName;
        private readonly IServiceProvider _serviceProvider;
        public BaseWorker(IServiceProvider serviceProvider, string jobName)
        {
            _serviceProvider = serviceProvider;
            _logger = GetService<ILogger<BaseWorker<TArgs>>>();
            _backgroundJobService = GetService<IBackgroundJobService>();
            JobName = jobName;
        }

        protected T? GetService<T>()
        {
            return _serviceProvider.CreateScope().ServiceProvider.GetService<T>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var job = _backgroundJobService.Dequeue(JobName);
                if (job != null)
                {
                    _logger.LogInformation($"{GetType().Name} is fired");
                    try
                    {
                        await DoWorkAsync(JsonConvert.DeserializeObject<TArgs>(job.JobArgs)!);
                        _backgroundJobService.DeleteJob(job.Id);
                    }
                    catch (Exception ex)
                    {
                        _backgroundJobService.JobError(job.Id, ex);
                        _logger.LogError($"{GetType().Name} has error: {ex.Message}");
                    }
                    _logger.LogInformation($"{GetType().Name} is completed");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        protected abstract Task DoWorkAsync(TArgs args);
    }
}
