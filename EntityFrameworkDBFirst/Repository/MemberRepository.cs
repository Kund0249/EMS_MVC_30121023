using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDBFirst.Model;
using EntityFrameworkDBFirst.DataContext;

namespace EntityFrameworkDBFirst.Repository
{
   public class MemberRepository
    {
        private readonly AssignmentContext db;
        public MemberRepository()
        {
            db = new AssignmentContext();
        }

        public List<MemberModel> GetMembers { get { return db.Members.ToList(); } }
    }
}
