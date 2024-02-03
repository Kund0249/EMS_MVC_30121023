using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDBFirst.Model
{
    [Table("TMEMBER")]
   public class MemberModel
    {
        [Column("EmployeeId")]
        public int EmployeeId { get; set; }

        [Key]
        [Column("UserId")]
        public string UserId { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
