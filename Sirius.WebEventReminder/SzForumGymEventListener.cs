// -----------------------------------------------------------------------
// <copyright file="SzForumGymEventListener.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.IO;
using System.Timers;
using HtmlAgilityPack;
using Sirius.WebEventReminder.Interfaces;
using Sirius.Common.Extensions;

namespace Sirius.WebEventReminder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SzForumGymEventListener : IEventListener
    {
        public event Action<object, EventHappenedEventArgs> EventHapped;
        public int currentPostCount = 0;

        public void Listen()
        {
            int interval = ConfigurationManager.AppSettings["ListenerInterval"].ToInt(20 * 60);
            Timer timer = new Timer(interval * 1000);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
            try
            {
                var doc = web.Load("http://szforum/viewforum.php?f=31");
                var posts = doc.DocumentNode.SelectNodes("//ul[@class='topiclist topics']")[1];
                var postCount = posts.SelectNodes("li").Count;

                if (postCount != currentPostCount)
                {
                    currentPostCount = postCount;
                    if (EventHapped != null)
                    {
                        var eventArgs = new EventHappenedEventArgs { Message = "New Post!" };
                        EventHapped(this, eventArgs);
                    }
                }
            }
            catch (Exception ex)
            {
                if (EventHapped != null)
                {
                    EventHapped(this, new EventHappenedEventArgs { Message = ex.Message });
                }
            }
        }
    }
}
