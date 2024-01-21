using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_MVC_30121023.Models.Employee
{
    public class EmployeeEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Mob { get; set; }
        public string Email { get; set; }
        public string FilePath { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public string BankAcc { get; set; }
        public DateTime Doj { get; set; }
    }
}