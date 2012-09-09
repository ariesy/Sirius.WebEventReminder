using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;

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

            StringWriter msgBodyWriter = new StringWriter();
            msgBodyWriter.WriteLine(eventArgs.Message);
            msgBodyWriter.WriteLine();
            msgBodyWriter.WriteLine("--------------------------------");
            msgBodyWriter.WriteLine("I'm glad that my service can help you.");
            msgBodyWriter.WriteLine("If there's any question feel free to send me email: ariesyzhk@gmail.com");
            msgBodyWriter.WriteLine("More interesting things can be found at my technique blog: http://kunzhu.co.cc");
            msgBodyWriter.WriteLine("and my code repository: https://github.com/ariesy");

            msg.Body = msgBodyWriter.ToString();
            msg.ReplyToList.Add(new MailAddress("ariesyzhk@gmail.com","Kun Zhu"));

            msg.Subject = eventArgs.Message;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("dev@kunzhu.co.cc", "dev.public");
            
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
