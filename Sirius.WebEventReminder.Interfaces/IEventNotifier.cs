using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.WebEventReminder.Interfaces
{
    public interface IEventNotifier<TReciever>
    {
        void SendNotification(object sender, EventHappenedEventArgs eventArgs);

        void Register(TReciever reciever);

        void Unregister(TReciever reciever);
    }
}
