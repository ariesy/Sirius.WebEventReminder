using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.WebEventReminder.Interfaces
{
    public interface IEventNotifier
    {
        void SendNotification(object sender, EventHappenedEventArgs eventArgs);

        void Register(object reciever);

        void Unregister(object reciever);
    }
}
