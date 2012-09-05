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
        public int currentPostCount = 0;

        public void Listen()
        {
            Timer timer = new Timer(60 * 1000 * 15);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
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
    }
}
