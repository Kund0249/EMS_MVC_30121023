using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDBFirst.DataContext;
using EntityFrameworkDBFirst.Model;
using EntityFrameworkDBFirst.Repository;

namespace EntityFrameworkDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //DepartmentModel model = new DepartmentModel()
            //{
            //    DeptCode = "TEST",
            //    DeptName = "TESTNAme"
            //};

            DepartmentRepository repository = new DepartmentRepository();
            var data = repository.departmentModels;
            //repository.Save(model);
            //bool IsDeleted = repository.Remove(32);


            //DepartmentModel model = new DepartmentModel()
            //{
            //    DeptId = 31,
            //    DeptCode = "TEST",
            //    DeptName = "TEST"
            //};

            //bool IsUpdated = repository.Update(model);

            //MemberRepository db = new MemberRepository();
            //var data = db.GetMembers;
        }
    }
}
