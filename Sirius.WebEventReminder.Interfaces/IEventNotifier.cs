using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.WebEventReminder.Interfaces
{
    public interface IEventNotifier
    {
        void SendNotification(EventHappenedEventArgs eventArgs);
    }
}
