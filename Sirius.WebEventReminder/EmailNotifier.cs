using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Sirius.WebEventReminder.Interfaces;

namespace Sirius.WebEventReminder
{
    public class EmailNotifier : IEventNotifier<string>
    {
        private HashSet<string> _emailAddr = new HashSet<string>();

        private string _fromAddr = "Kun.zhu@moodys.com";

        public void SendNotification(object sender, EventHappenedEventArgs eventArgs)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_fromAddr);

            foreach (var address in _emailAddr)
            {
                msg.To.Add(address);
            }

            msg.Body = eventArgs.Message;
            msg.Subject = eventArgs.Message;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            
            try
            {
                smtpClient.Send(msg);
            }
            catch (Exception e)
            {
                //TODO: handle exception.
                string s = e.Message;
                Console.Write(s);
            }
        }

        public void Register(string reciever)
        {
            if (!_emailAddr.Contains(reciever))
            {
                _emailAddr.Add(reciever);
            }
        }

        public void Unregister(string reciever)
        {
            if (_emailAddr.Contains(reciever))
            {
                _emailAddr.Remove(reciever);
            }
        }
    }
}
