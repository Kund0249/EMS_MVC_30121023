using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EMS_MVC_30121023.Controllers
{
    public enum MessageType
    {
        success,error,warning,info
    }
    public class APPController : Controller
    {
        // GET: APP
        public void Notification(string Title,string Message, MessageType messageType)
        {
            string MessageType = string.Empty;
            switch (messageType)
            {
                case Controllers.MessageType.success:
                    MessageType = "success";
                    break;
                case Controllers.MessageType.error:
                    MessageType = "error";
                    break;
                case Controllers.MessageType.warning:
                    MessageType = "warning";
                    break;
                case Controllers.MessageType.info:
                    MessageType = "info";
                    break;
                default:
                    break;
            }

            var alertmessage = new
            {
                Title = Title,
                Message = Message,
                MessageType = MessageType
            };
            var JSConverter = new JavaScriptSerializer();
            TempData["Message"] = JSConverter.Serialize(alertmessage);
        }
    }
}