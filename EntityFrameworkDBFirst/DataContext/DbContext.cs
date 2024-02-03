using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFrameworkDBFirst.Model;

namespace EntityFrameworkDBFirst.DataContext
{
    class AssignmentContext : DbContext
    {
        public AssignmentContext():base("name=DBCon")
        {

        }

        public DbSet<DepartmentModel> Departments { get; set; }

        public DbSet<MemberModel> Members { get; set; }
    }
}
