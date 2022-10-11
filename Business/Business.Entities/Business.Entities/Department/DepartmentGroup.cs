﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Department
{
    public class DepartmentGroup

    {
        public int DepartmentGroupID { get; set; }
        
        [Required(ErrorMessage = "Please Enter New Department Group Name")]
        public string DepartmentGroupText { get; set; }

        [Required(ErrorMessage = "Please Enter Department Group Remark")]
        [RegularExpression("([A-Za-z])+( [A-Za-z]+)*", ErrorMessage="Please enter text only")]
        public string Remark { get; set; }
       
        public bool IsActive { get; set; } = true;

        public int CreatedOrModifiedBy { get; set; }
    }
}
