using BackgroundJobsWebApi.Domain.Models;
using BackgroundJobsWebApi.Service.Services.Abstracts;
using BackgroundJobsWebApi.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Service.Services.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly IBackgroundJobService _backgroundJobService;

        public EmailService(IBackgroundJobService backgroundJobService)
        {
            _backgroundJobService = backgroundJobService;
        }

        static int Count = 0;
        public async Task SendAsync(string to, string subject, string body)
        {
            #region Fake logic send email ...
            Count++;
            if (Count % 3 == 0)
            {
                throw new Exception($"Send email to {to}. It's throw exception because {Count} divisible by 3.");
            }
            await Task.Delay(10000);
            #endregion
        }

        public void EnqueueEmail(string to, string subject, string body)
        {
            _backgroundJobService.Enqueue(BackgroundJobNameConstants.SendEmail,
                new EmailJobArgs
                {
                    Body = body,
                    Subject = subject,
                    To = to,
                });
        }
    }
}
