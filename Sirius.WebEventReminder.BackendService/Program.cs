using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.WebEventReminder.Interfaces;
using Sirius.Messaging.Interfaces;

namespace Sirius.WebEventReminder.BackendService
{
    class Program
    {
        private static IEventNotifier _notifier;

        static void Main(string[] args)
        {
            IEventListener listener = new SzForumGymEventListener();
            IMessageQueue messageQueue = null;
            messageQueue.OnEnqueue += MessageQueue_OnEnqueue;
            listener.Listen();
            listener.EventHapped += Listener_EventHapped;
            listener.EventHapped += _notifier.SendNotification;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        static void MessageQueue_OnEnqueue(object emailAddress)
        {
            _notifier.Register(emailAddress.ToString());
        }

        static void Listener_EventHapped(object sender, EventHappenedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
