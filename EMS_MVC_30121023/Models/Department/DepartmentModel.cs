using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EMS_MVC_30121023.Models.Department
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }

        
        [Required(ErrorMessage = "DepartmentCode is mandatory.")]
        [RegularExpression("[a-zA-Z]*",ErrorMessage ="Only Alphbets are allowed.")]
        [StringLength(6,ErrorMessage ="Max length is 6 character")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "DepartmentName is mandatory")]
        [RegularExpression("[a-zA-Z\\s]*", ErrorMessage = "Only Alphbets are allowed.")]
        public string DepartmentName { get; set; }
    }
}