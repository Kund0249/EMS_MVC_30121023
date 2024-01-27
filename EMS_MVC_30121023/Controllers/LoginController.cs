using EMS_MVC_30121023.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS_MVC_30121023.Controllers
{
    [AllowAnonymous]
    public class LoginController : APPController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if(model.UserId == "admin" && model.Password == "123456")
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserId,false);
            }
            Notification("Invalid Credentials", "Incorrect userid or password!", MessageType.error);
            return View();
        }
    }
}