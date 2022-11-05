using BackgroundJobsWebApi.Domain.Models;
using BackgroundJobsWebApi.Service.Services.Abstracts;
using BackgroundJobsWebApi.Shared.Constants;

namespace BackgroundJobsWebApi.Workers
{
    public class EmailSendingWorker : BaseWorker<EmailJobArgs>
    {
        private readonly IEmailService _emailService;
        public EmailSendingWorker(IServiceProvider serviceProvider) 
            : base(serviceProvider, BackgroundJobNameConstants.SendEmail)
        {
            _emailService = GetService<IEmailService>();
        }

        protected override async Task DoWorkAsync(EmailJobArgs args)
        {
            await _emailService.SendAsync(args.To, args.Subject, args.Body);
        }
    }
}
