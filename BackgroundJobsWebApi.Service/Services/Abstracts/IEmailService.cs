using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Service.Services.Abstracts
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
        void EnqueueEmail(string to, string subject, string body);
    }
}
