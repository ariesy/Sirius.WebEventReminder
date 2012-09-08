using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Common.Ioc;
using Sirius.WebEventReminder.Interfaces;
using Sirius.Messaging.Interfaces;
using Sirius.Messaging;

namespace Sirius.WebEventReminder.BackendService
{
    class Program
    {
        private static IEventNotifier _notifier;

        static void Main(string[] args)
        {
            IocContainer.Current.LoadConfiguration();
            IEventListener listener = new SzForumGymEventListener();
            IMessageQueueServer messageQueueServer = new MessageQueueServer();
            _notifier = new EmailNotifier();
            messageQueueServer.ItemsEnqued += new Action<List<IMessage>>(messageQueueServer_ItemsEnqued);
            IMessageQueue messageQueue = new MessageQueue();
            CommonMessage message = new CommonMessage { MessageBody = "ariesyzhk@gmail.com" };
            messageQueue.Enqueue(message);
            listener.Listen();
            listener.EventHapped += Listener_EventHapped;
            listener.EventHapped += _notifier.SendNotification;
            messageQueueServer.Start();
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        static void messageQueueServer_ItemsEnqued(List<IMessage> messages)
        {
            foreach (var msg in messages)
            {
                _notifier.Register(msg.MessageBody);
            }
        }

        static void Listener_EventHapped(object sender, EventHappenedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
