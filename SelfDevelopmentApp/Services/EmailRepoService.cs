using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Utilities;

namespace SelfDevelopmentApp.Services
{
    public class EmailRepoService : IEmailRepository
    {
        private readonly EmailConfig ec;

        public EmailRepoService(IOptions<EmailConfig> emailConfig)
        {
            this.ec = emailConfig.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(ec.UserId, ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //    private AppDbContext AppDbContext { get; }

            //    public EmailRepoService(AppDbContext appDbContext)
            //    {
            //        AppDbContext = appDbContext;
            //    }


            //    public Task StartAsync(CancellationToken cancellationToken)
            //    {
            //        Task.Run(TaskRoutine, cancellationToken);
            //        return Task.CompletedTask;
            //    }

            //    public Task StopAsync(CancellationToken cancellationToken)
            //    {
            //        Console.WriteLine("Sync Task stopped");
            //        return null;
            //    }

            //    public Task TaskRoutine()
            //    {

            //        while (true)
            //        {
            //            foreach (var user in AppDbContext.Users.Include(u => u.ToDoList).Include(u => u.Habits).ToList())
            //            {
            //                foreach (var item in user.ToDoList.ListItems)
            //                {
            //                    if (!item.Done)
            //                    {
            //                        if (item.ReminderTime <= DateTime.Now)
            //                        {
            //                            string emailBody = "It is time of your todo item " + item.Description;
            //                            SendEmail(emailBody);
            //                        }

            //                        if (item.DueDate <= DateTime.Now)
            //                        {
            //                            string emailBody = "Oops! it is the due date of your todo item "
            //                                                + item.Description;
            //                            SendEmail(emailBody);
            //                        }
            //                    }
            //                }
            //            }



            //            //Wait 10 minutes till next execution
            //            DateTime nextStop = DateTime.Now.AddMinutes(10);
            //            var timeToWait = nextStop - DateTime.Now;
            //            var millisToWait = timeToWait.TotalMilliseconds;
            //            Thread.Sleep((int)millisToWait);
            //        }
            //    }

            //    public void SendEmail(/* USER Email*/ string emailBody)
            //    {
            //        MimeMessage message = new MimeMessage();

            //        MailboxAddress from = new MailboxAddress("SALAM",
            //        "testsendingemail55@gmail.com");
            //        message.From.Add(from);


            //        // user Email
            //        MailboxAddress to = new MailboxAddress("User",
            //        "na1556@fayoum.edu.eg");
            //        message.To.Add(to);

            //        message.Subject = "This is email subject";

            //        BodyBuilder bodyBuilder = new BodyBuilder();
            //        bodyBuilder.HtmlBody = "<h1>"+emailBody+"</h1>";
            //        bodyBuilder.TextBody = emailBody;
            //        message.Body = bodyBuilder.ToMessageBody();

            //        SmtpClient client = new SmtpClient();
            //        client.Connect("Smtp.gmail.com", 465, true);
            //        client.Authenticate("testsendingemail55@gmail.com", "1234567898testsendemail");

            //        client.Send(message);
            //        client.Disconnect(true);
            //        //client.Dispose();

            //    }

        }
    }
}
