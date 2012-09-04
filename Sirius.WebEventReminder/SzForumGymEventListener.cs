// -----------------------------------------------------------------------
// <copyright file="SzForumGymEventListener.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.IO;
using System.Threading;
using Sirius.Http;
using Sirius.WebEventReminder.Interfaces;

namespace Sirius.WebEventReminder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SzForumGymEventListener : IEventListener
    {
        public event Action<object, EventHappenedEventArgs> EventHapped;

        public void Listen()
        {
            AutoResetEvent autoEvent     = new AutoResetEvent(false);
            Timer timer = new Timer(CheckPost, autoEvent, 1000 * 60 * 15, 1000 * 60 * 15);
            autoEvent.WaitOne();

            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += WorkerDoWork;
        }

        private void CheckPost(object state)
        {
            var s = "1";
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            HttpConnection connection = new HttpConnection();
            using (Stream responseStream = connection.Get("http://szforum/viewforum.php?f=31"))
            {
                StreamReader reader = new StreamReader(responseStream);
                reader.ReadToEnd();
                EventHappenedEventArgs eventArgs = new EventHappenedEventArgs();
            }
        }
    }
}
