using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.WebEventReminder;
using Sirius.WebEventReminder.Interfaces;
using NUnit.Framework;

namespace Sirius.WebEventReminder.Tests
{
    [TestFixture]
    public class EmailNotifierTests
    {
        [Test]
        public void TestSendNotification()
        {
            var target = new EmailNotifier();
            target.RegisterEmailAddress("ariesyzhk@gmail.com");
            Assert.DoesNotThrow(() =>
                {
                    target.SendNotification(new EventHappenedEventArgs { Message = "test" });
                });
        }
    }
}
