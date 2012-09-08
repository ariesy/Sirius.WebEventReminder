using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirius.Common.Ioc;
using Sirius.Messaging.Interfaces;
using Sirius.Messaging;

namespace Sirius.WebEventReminder.Register.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Please register your email:";

            return View();
        }

        public ActionResult Register(string email)
        {
            IMessage message = new CommonMessage { MessageBody = email };
            IMessageQueue msgQueue = new MessageQueue(); 
            msgQueue.Enqueue(message);
            ViewBag.Message = "Register succeed!";
            return View();
        }

        public ActionResult UnRegister(string email)
        {
            if (email == null)
            {
                ViewBag.Unregister = false;
            }
            else
            {
                ViewBag.Unregister = true;
                IMessage message = new CommonMessage { MessageBody = email };
                IMessageQueue msgQueue = new MessageQueue();
                msgQueue.Dequeue(message);
            }

            return View();
        }
    }
}
