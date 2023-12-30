using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS_MVC_30121023.Controllers
{
    public class EmployeeController : Controller
    {
        public string GetMessage()
        {
            return "Hello from EMS MVC Application";
        }

        public string GetMessage2(string name)
        {
            return "Hello "+name+ ", Welcome to EMS MVC Application";
        }
    }
}