using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EMS_MVC_30121023.Models.Department;

namespace EMS_MVC_30121023.Models.Employee
{
    public class EmployeeModel
    {
        private readonly DepartmentRepository repository;
        public EmployeeModel()
        {
            repository = new DepartmentRepository();
            DepartmentList = new List<SelectListItem>();
            foreach (DepartmentModel department in repository.GetDepartments)
            {
                DepartmentList.Add(new SelectListItem()
                {
                    Text = department.DepartmentName,
                    Value = department.DepartmentId.ToString()
                });
            }
        }
        public List<SelectListItem> DepartmentList { get; }
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DOJ { get; set; }

        [Required]
        [Range(500000, 3000000)]
        public int Salary { get; set; }

        [Required]
        public string BankAcc { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("BankAcc")]
        public string CnfBankAcc { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public HttpPostedFileBase ProfilePicture { get; set; }


        public static EmployeeEntity Convert(EmployeeModel model, String filename)
        {
            EmployeeEntity emp = new EmployeeEntity()
            {
                Name = model.Name,
                Gender = model.Gender,
                Email = model.EmailAddress,
                BankAcc = model.BankAcc,
                DepartmentId = model.DepartmentId,
                Doj = model.DOJ,
                Mob = model.ContactNumber,
                Salary = model.Salary,
                FilePath = filename
            };
            return emp;
        }
    }
}