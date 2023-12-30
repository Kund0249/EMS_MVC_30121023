using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_MVC_30121023.Models;

namespace EMS_MVC_30121023.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _repository;
        public DepartmentController()
        {
            _repository = new DepartmentRepository();
        }
        //public string Index()
        //{
        //    return "Hello from Department Controller";
        //}

        public ViewResult Index()
        {
            List<DepartmentModel> models = _repository.GetDepartments;
            return View(models);
        }
        
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public RedirectToRouteResult Create(string DepartmentCode,string DepartmentName)
        //{
        //    DepartmentModel model = new DepartmentModel()
        //    {
        //        DepartmentCode = DepartmentCode,
        //        DepartmentName = DepartmentName
        //    };
        //    _repository.Save(model);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public RedirectToRouteResult Create(DepartmentModel model)
        {
            _repository.Save(model);

            return RedirectToAction("Index");
        }
    }
}