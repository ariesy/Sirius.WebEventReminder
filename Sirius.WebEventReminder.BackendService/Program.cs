using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.WebEventReminder.Interfaces;

namespace Sirius.WebEventReminder.BackendService
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventListener listener = new SzForumGymEventListener();
            listener.Listen();
            listener.EventHapped += Listener_EventHapped;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        static void Listener_EventHapped(object sender, EventHappenedEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
