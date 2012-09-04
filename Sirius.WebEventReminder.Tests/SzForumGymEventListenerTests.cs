// -----------------------------------------------------------------------
// <copyright file="SzForumGymEventListenerTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using NUnit.Framework;

namespace Sirius.WebEventReminder.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class SzForumGymEventListenerTests
    {
        [Test]
        public void TestListen()
        {
            var target = new SzForumGymEventListener();
            target.Listen();
        }
    }
}
