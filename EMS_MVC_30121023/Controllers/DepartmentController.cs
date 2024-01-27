using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EMS_MVC_30121023.Models.Department;

namespace EMS_MVC_30121023.Controllers
{
    //Controller Lavel Filter
    //[Authorize]
    public class DepartmentController : APPController
    {
        private readonly DepartmentRepository _repository;
        public DepartmentController()
        {
            _repository = new DepartmentRepository();
        }
        //Action
        //EndPoint
        [HttpGet]
        //Action Lavel Filter
        //[Authorize]
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
        [Route("AddDepartment")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (_repository.Save(model, out string errormessage))
                {
                    //var alertmessage = new
                    //{
                    //    Title = "Success Message",
                    //    Message = "Record Created Successfully!",
                    //    MessageType = "success"
                    //};

                    ////string message = "Record Created Successfully!";

                    //var JSConverter = new JavaScriptSerializer();
                    //TempData["Message"] = JSConverter.Serialize(alertmessage);

                    Notification("Sucees", "Record Create successfully",MessageType.success);
                    return RedirectToAction("Index");
                }
                else
                    Notification("Error", errormessage, MessageType.error);

            }

            return View();
        }


        [HttpGet]
        [Route("ModifyDepartment/{id}")]
        public ActionResult Edit(int id)
        {
            DepartmentModel model = _repository.GetDepartment(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult Edit(DepartmentModel model)
        {
            if (_repository.Update(model, out string Message))
            {
                Notification("Sucees", "Record updated successfully", MessageType.success);

                return RedirectToAction("Index");
            }
            Notification("warning", Message, MessageType.warning);

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_repository.Remove(id, out string Message))
                Notification("Success", "Record delete successfully!", MessageType.success);
            else
                Notification("Error", Message, MessageType.error);

            return RedirectToAction("Index");
        }
    }
}