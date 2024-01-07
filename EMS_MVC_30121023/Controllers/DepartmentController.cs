using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_MVC_30121023.Models.Department;

namespace EMS_MVC_30121023.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _repository;
        public DepartmentController()
        {
            _repository = new DepartmentRepository();
        }
        //Action
        //EndPoint
        [HttpGet]
        public ViewResult Index()
        {
            //if (TempData["Message"] != null)
            //    ViewBag.Message = TempData["Message"];

            //string Message = "Hello John - from Index Action Method";
            //object ob = Message;
            // return View(ob);
            //DepartmentModel model = new DepartmentModel()
            //{
            //    DepartmentId = 1,
            //    DepartmentCode = "HR",
            //    DepartmentName = "Human Resource"
            //};
            //return View(model);

                //List<DepartmentModel> models = new List<DepartmentModel>()
                //{
                //    new DepartmentModel()
                //    {
                //        DepartmentId = 1,
                //        DepartmentCode = "HR",
                //        DepartmentName = "Human Resource"
                //    },
                //     new DepartmentModel()
                //    {
                //        DepartmentId = 2,
                //        DepartmentCode = "MR",
                //        DepartmentName = "Manager"
                //    },
                //      new DepartmentModel()
                //    {
                //        DepartmentId = 3,
                //        DepartmentCode = "DPTR",
                //        DepartmentName = "Department Manager"
                //    }
                //};

                //return View(models);

            var data = _repository.GetDepartments;
            return View(data);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel model)
        {
            //code to save data
            if (_repository.Save(model,out string errormessage))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Message = errormessage;
                return View();
            }
              
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_repository.Remove(id, out string Message))
                TempData["Message"] = "Record Removed successfully!";
            else
                TempData["Message"] = Message;

           return RedirectToAction("Index");
        }
    }
}