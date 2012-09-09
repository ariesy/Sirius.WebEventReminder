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
        private static List<IMessageQueueServer> _msgQueueServers = new List<IMessageQueueServer>();

        static void Main(string[] args)
        {
            IocContainer.Current.LoadConfiguration();
            
            IMessageQueueServer gymMessageQueueServer = new MessageQueueServer(DomainList.Gym);
            IMessageQueueServer badmintonMessageQueueServer = new MessageQueueServer(DomainList.Badminton);
            _msgQueueServers.Add(gymMessageQueueServer);
            _msgQueueServers.Add(badmintonMessageQueueServer);

            _notifier = new EmailNotifier();

            gymMessageQueueServer.ItemsEnqued += new Action<List<IMessage>>(messageQueueServer_ItemsEnqued);
            gymMessageQueueServer.ItemDequeued += new Action<List<IMessage>>(gymMessageQueueServer_ItemDequeued);

            IEventListener listener = new SzForumGymEventListener();
            listener.Listen();
            listener.EventHapped += Listener_EventHapped;
            listener.EventHapped += _notifier.SendNotification;
            gymMessageQueueServer.Start();
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
            Stop();
        }

        static void gymMessageQueueServer_ItemDequeued(List<IMessage> deletedMsgs)
        {
            foreach (var msg in deletedMsgs)
            {
                _notifier.Unregister(msg.MessageBody);
            }
        }

        private static void Stop()
        {
            foreach (var server in _msgQueueServers)
            {
                server.Stop();
            }
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
