using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGS.Email
{
    public interface IEmailSender
    {
        Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}
