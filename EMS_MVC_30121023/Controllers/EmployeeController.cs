using EMS_MVC_30121023.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS_MVC_30121023.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly EmployeeRepository repository;
        public EmployeeController()
        {
            repository = new EmployeeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                string filename = null;
                if (model.ProfilePicture != null)
                {
                    string guidId = Guid.NewGuid().ToString();
                    filename = guidId + "_" + model.ProfilePicture.FileName;
                    model.ProfilePicture.SaveAs(Server.MapPath("~/EmpImages/" + filename));
                }
                repository.Save(EmployeeModel.Convert(model, filename));
                ModelState.Clear();
            }
            return View(model);
        }
    }
}