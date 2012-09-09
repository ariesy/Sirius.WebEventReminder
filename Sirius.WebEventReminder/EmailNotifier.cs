using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;
using Sirius.Net.Mail;

namespace Sirius.WebEventReminder
{
    public class EmailNotifier : IEventNotifier
    {
        private HashSet<string> _emailAddr = new HashSet<string>();

        public void SendNotification(object sender, EventHappenedEventArgs eventArgs)
        {
            if (_emailAddr.Count == 0)
            {
                Console.WriteLine("No register");
                return;
            }

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("dev@kunzhu.co.cc", "Kun Zhu");

            foreach (var address in _emailAddr)
            {
                msg.To.Add(address);
            }

            msg.Body = eventArgs.Message;

            msg.Subject = eventArgs.Message;
            DevPublicSmtpClient smtpClient = new DevPublicSmtpClient();
            
            try
            {
                smtpClient.Send(msg);
                Console.WriteLine("Succeed:" + string.Join(",", _emailAddr.ToArray()));
            }
            catch (Exception e)
            {
                //TODO: handle exception.
                string s = e.Message;
                Console.WriteLine(s + ":" + string.Join(",", _emailAddr.ToArray()));
            }
        }

        public void Register(object reciever)
        {
            if (reciever == null)
            {
                return;
            }

            if (!_emailAddr.Contains(reciever.ToString()))
            {
                _emailAddr.Add(reciever.ToString());
            }
        }

        public void Unregister(object reciever)
        {
            if (reciever == null)
            {
                return;
            }

            if (_emailAddr.Contains(reciever.ToString()))
            {
                _emailAddr.Remove(reciever.ToString());
            }
        }
    }
}
