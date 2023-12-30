using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_MVC_30121023.Models
{
    public class DepartmentRepository
    {
        public static List<DepartmentModel> departmentList;

        static DepartmentRepository()
        {
            departmentList = new List<DepartmentModel>()
            {
                new DepartmentModel(){DepartmentCode="Admin",DepartmentName="System Admin"},
                new DepartmentModel(){DepartmentCode="HR" , DepartmentName="Human Resources"},
                new DepartmentModel(){DepartmentCode="DEPMGR",DepartmentName="Department Manager"}
            };
        }
        public List<DepartmentModel> GetDepartments
        {
            get
            {
                //get data from DB and return it
                return departmentList;

            }
        }
        public void Save(DepartmentModel model)
        {
            //save to DB
            //Command cmd  = new Command("spInsert",Con);
            //cmd.parameters.addwithvalue("@DeptCode",model.DepartmentCode)
            departmentList.Add(model);
        }

        public void Modify(DepartmentModel model)
        {
            //save to DB
        }

        public bool Remove(int DepartmentId)
        {
            //save to DB
            return true;
        }
    }
}