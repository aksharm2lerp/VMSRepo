using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;*/
using System.ComponentModel.DataAnnotations;
/*using System.ComponentModel.DataAnnotations.Schema;
*/
namespace Business.Entities.Department
{
    public class Department
    {
        
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Enter the Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Please Enter the Department Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter the Department Group")]
        public string DepartmentGroupText { get; set; }

        [Required(ErrorMessage = "Please Enter the Department Group ID")]
        public int DepartmentGroupID { get; set; }

        [Required(ErrorMessage = "Please Select the Check Box")]
        public Boolean IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CreatedOrModifiedBy { get; set; }

       
    }
}
