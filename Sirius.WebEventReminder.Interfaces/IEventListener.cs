// -----------------------------------------------------------------------
// <copyright file="IEventListener.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Sirius.WebEventReminder.Interfaces
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IEventListener
    {
        event Action<object, EventHappenedEventArgs> EventHapped;

        void Listen();
    }
}
