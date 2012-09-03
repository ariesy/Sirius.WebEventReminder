// -----------------------------------------------------------------------
// <copyright file="HttpConnectionTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using NUnit.Framework;

namespace Sirius.Http.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class HttpConnectionTests
    {
        [Test]
        public void TestGet()
        {
            HttpConnection target = new HttpConnection();
            Assert.NotNull(target.Get("http://kunzhu.co.cc"));
        }
    }
}
