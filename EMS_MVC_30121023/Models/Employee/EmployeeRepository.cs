using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_MVC_30121023.Models.Employee
{
    public class EmployeeRepository
    {
        string CS = string.Empty;
        public EmployeeRepository()
        {
            CS = "";
        }

        public bool Save(EmployeeEntity entity)
        {
            //Write the code to save data in DataBase;
            return true;
        }
    }
}