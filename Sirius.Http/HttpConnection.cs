// -----------------------------------------------------------------------
// <copyright file="HttpConnection.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Net;

namespace Sirius.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class HttpConnection
    {
        public string UserName { get; private set; }

        public string Password { get; private set; }

        private CookieContainer _cookies = new CookieContainer();

        public HttpConnection(string userName = "", string password = "")
        {
            UserName = userName;
            Password = password;
        }

        public Stream Get(string url)
        {  
            try
            {
                HttpWebRequest request = null;
                request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = _cookies;
                request.KeepAlive = true;
                var response = request.GetResponse() as HttpWebResponse;
                return response.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }

        public Stream Post(string url, object PostData)
        {
            try
            {
                HttpWebRequest request = null;
                request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = _cookies;
                var cookie = new Cookie("wordpress_test_cookie", "WP+Cookie+check");
                cookie.Domain = "Kunzhu.co.cc";
                request.CookieContainer.Add(cookie);
                request.Method = "POST";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.8 (KHTML, like Gecko) Chrome/23.0.1251.2 Safari/537.8";
                using (var requestStream = request.GetRequestStream())
                {
                    StreamWriter sw = new StreamWriter(requestStream);
                    sw.Write(PostData);
                }

                var response = request.GetResponse() as HttpWebResponse;
                return response.GetResponseStream();
            }
            catch(Exception e)
            {
                var s = e.Message;
                return null;
            }
        }
    }
}
