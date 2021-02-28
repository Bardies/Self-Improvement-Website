using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
