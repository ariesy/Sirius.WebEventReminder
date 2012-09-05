using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.WebEventReminder.MessageQueue.Interface
{
    public interface IMessageQueue<TItem>
    {
        bool Enqueue(TItem item);

        event Action<TItem> OnEnqueue;
    }
}
