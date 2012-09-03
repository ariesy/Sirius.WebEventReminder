﻿// -----------------------------------------------------------------------
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
                request.CookieContainer = _cookies;
                request = HttpWebRequest.Create(url) as HttpWebRequest;
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
                request.CookieContainer = _cookies;
                request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                using (var requestStream = request.GetRequestStream())
                {
                    StreamWriter sw = new StreamWriter(requestStream);
                    sw.Write(PostData);
                }

                var response = request.GetResponse() as HttpWebResponse;
                return response.GetResponseStream();
            }
            catch
            {
                return null;
            }
        }
    }
}
