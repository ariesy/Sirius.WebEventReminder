using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.WebEventReminder.Interfaces;
using Sirius.WebEventReminder.Messaging.Interfaces;

namespace Sirius.WebEventReminder.BackendService
{
    class Program
    {
        private static IEventNotifier<string> _notifier;

        static void Main(string[] args)
        {
            IEventListener listener = new SzForumGymEventListener();
            IMessageQueue<string> messageQueue;
            messageQueue.OnEnqueue += MessageQueue_OnEnqueue;
            listener.Listen();
            listener.EventHapped += Listener_EventHapped;
            listener.EventHapped += _notifier.SendNotification;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        static void MessageQueue_OnEnqueue(string emailAddress)
        {
            _notifier.Register(emailAddress);
        }

        static void Listener_EventHapped(object sender, EventHappenedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
