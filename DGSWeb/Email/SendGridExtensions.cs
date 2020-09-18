using DGSWeb.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.Email
{
    public static class SendGridExtensions
    {
        // class for configuring email sender pipeline
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            // creating a new instance of this action service everytime the action is to be used
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
