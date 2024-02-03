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
    //[HandleError]
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

        [Route("")]
        [OutputCache(Duration =30)]
        public ViewResult Index()
        {
            //Session["Name"] = "Name";
            //ViewBag.Names = new string[] { "Option-1", "Option-2", "Option-3" };
            //ViewData["NamesD"] = new string[] { "Option-4", "Option-5", "Option-6" };
            //throw new Exception("CUstome error");
            var data = _repository.GetDepartments;
            return View(data);
        }

        [HttpGet]
        //[Route("AddDepartment")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("AddDepartment")]
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
        //[Route("ModifyDepartment/{id}")]
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
        //[Route("ModifyDepartment")]
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