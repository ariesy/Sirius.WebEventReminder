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
    using System.IO;

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
            using (var stream = target.Get("http://kunzhu.co.cc"))
            {
                StreamReader reader = new StreamReader(stream);
                var s = reader.ReadToEnd();
                Assert.NotNull(s);
            }
            
            
        }

        [Test]
        public void TestPost()
        {
            HttpConnection target = new HttpConnection();

            using (var stream = target.Post("http://kunzhu.co.cc/wordpress/wp-login.php", "log=ariesy&pwd=sparky_zhk&remeberme=forever&wp-submit=登录&redirect_to=http://kunzhu.co.cc/wordpress/wp-admin/"))
            {
                StreamReader sr = new StreamReader(stream);
                var s = sr.ReadToEnd();
                Assert.NotNull(s);
            }

            using (var stream = target.Get("http://kunzhu.co.cc/wordpress/wp-admin/"))
            {
                StreamReader reader = new StreamReader(stream);
                var s = reader.ReadToEnd();
                Assert.NotNull(s);
            }
        }
    }
}
