using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDBFirst.Model
{
    [Table("TDEPARTMENT")]
  public  class DepartmentModel
    {
        [Key]
        [Column("DepartmentId")]
        public int DeptId { get; set; }

        [Column("DepartmentCode")]
        public string DeptCode { get; set; }

        [Column("DepartmentName")]
        public string DeptName { get; set; }
    }
}
