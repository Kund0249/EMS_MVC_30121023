using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDBFirst.Model;
using EntityFrameworkDBFirst.DataContext;

namespace EntityFrameworkDBFirst.Repository
{
    public class DepartmentRepository
    {
        private readonly AssignmentContext db;
        public DepartmentRepository()
        {
            db = new AssignmentContext();
        }

        public List<DepartmentModel> departmentModels
        {
            get
            {
                return db.Departments.ToList();
            }
        }
        public bool Save(DepartmentModel model)
        {
            var data = db.Departments.Add(model);
            db.SaveChanges();
            if (data != null)
            {
                return true;
            }
            return false;
        }

        public bool Remove(int DepartmentId)
        {
            var data = db.Departments.SingleOrDefault(x => x.DeptId == DepartmentId);
            if (data != null)
            {
                db.Departments.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(DepartmentModel model)
        {
            var data = db.Departments.SingleOrDefault(x => x.DeptId == model.DeptId);
            if (data != null)
            {
                data.DeptCode = model.DeptCode;
                data.DeptName = model.DeptName;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
